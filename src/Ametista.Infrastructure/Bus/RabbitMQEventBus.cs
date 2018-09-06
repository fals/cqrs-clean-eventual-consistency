using Ametista.Core;
using Ametista.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ametista.Infrastructure.Bus
{
    public class RabbitMQEventBus : IEventBus, IDisposable
    {
        private readonly string QUEUE_NAME = "ametista_events";
        private readonly IEventDispatcher eventDispatcher;

        public RabbitMQEventBus(IEventDispatcher eventDispatcher)
        {
            this.eventDispatcher = eventDispatcher ?? throw new ArgumentNullException(nameof(eventDispatcher));

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new NonPublicPropertiesResolver()
            };
        }

        public void Publish(IEvent @event)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var eventName = @event.GetType().Name;

                    channel.ExchangeDeclare(exchange: QUEUE_NAME, type: "fanout");
                    channel.QueueBind(QUEUE_NAME, QUEUE_NAME, eventName);

                    string message = JsonConvert.SerializeObject(@event);
                    var body = Encoding.UTF8.GetBytes(message);
                   
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2; // persistent

                    channel.BasicPublish(exchange: QUEUE_NAME,
                                     routingKey: eventName,
                                     mandatory: true,
                                     basicProperties: properties,
                                     body: body);
                }
            }
        }

        public class NonPublicPropertiesResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var prop = base.CreateProperty(member, memberSerialization);
                if (member is PropertyInfo pi)
                {
                    prop.Readable = (pi.GetMethod != null);
                    prop.Writable = (pi.SetMethod != null);
                }
                return prop;
            }
        }

        public void Subscribe<T>() where T : IEvent
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            {
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
                        var subType = typeof(T).Name;

                        try
                        {
                            if (subType == @event.Name)
                            {
                                eventDispatcher.Dispatch(@event);

                                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    };

                    channel.BasicConsume(queue: QUEUE_NAME, autoAck: false, consumer: consumer);
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~RabbitMQEventBus() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}