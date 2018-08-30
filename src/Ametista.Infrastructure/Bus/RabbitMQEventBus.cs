using Ametista.Core;
using Ametista.Core.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Ametista.Infrastructure.Bus
{
    public class RabbitMQEventBus : IEventBus
    {
        private readonly string QUEUE_NAME = "ametista_events";
        private readonly IEventDispatcher eventDispatcher;

        public RabbitMQEventBus(IEventDispatcher eventDispatcher)
        {
            this.eventDispatcher = eventDispatcher ?? throw new ArgumentNullException(nameof(eventDispatcher));
        }

        public void Publish(IEvent @event)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: QUEUE_NAME, type: "fanout");

                string message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);
                var eventName = @event.GetType().Name;

                var properties = channel.CreateBasicProperties();
                properties.DeliveryMode = 2; // persistent

                channel.BasicPublish(exchange: QUEUE_NAME,
                                 routingKey: eventName,
                                 mandatory: true,
                                 basicProperties: properties,
                                 body: body);
            }
        }

        public void Subscribe<T>() where T : IEvent
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: QUEUE_NAME, type: "fanout");

                channel.QueueDeclare(queue: QUEUE_NAME, durable: true, exclusive: false, autoDelete: false, arguments: null);

                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var @event = JsonConvert.DeserializeObject<T>(message);

                    eventDispatcher.Dispatch(@event);

                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };

                channel.BasicConsume(queue: QUEUE_NAME, autoAck: false, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}