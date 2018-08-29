using Ametista.Core;
using Ametista.Core.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

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
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: QUEUE_NAME,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);
                var eventName = @event.GetType().Name;

                channel.BasicPublish(exchange: "",
                                     routingKey: eventName,
                                     basicProperties: null,
                                     body: body);
            }
        }

        public void Subscribe<T>() where T : IEvent 
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var eventName = typeof(T).Name;

                channel.QueueDeclare(queue: eventName, durable: true, exclusive: false, autoDelete: false, arguments: null);

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
            }
        }
    }
}