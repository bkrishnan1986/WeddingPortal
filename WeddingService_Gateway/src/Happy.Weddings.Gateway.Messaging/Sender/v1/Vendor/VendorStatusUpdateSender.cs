using Happy.Weddings.Gateway.Core.Domain.Vendor;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Messaging.Sender.v1.Vendor;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Happy.Weddings.Gateway.Messaging.Sender.v1.Vendor
{
    public class VendorStatusUpdateSender : IUpdateVendorStatusSender
    {
        /// <summary>
        /// The hostname
        /// </summary>
        private readonly string hostname;

        /// <summary>
        /// The queue name
        /// </summary>
        private readonly string queueName;

        /// <summary>
        /// The exchange name
        /// </summary>
        private readonly string exchangeName;

        /// <summary>
        /// The username
        /// </summary>
        private readonly string username;

        /// <summary>
        /// The password
        /// </summary>
        private readonly string password;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsernameUpdateSender"/> class.
        /// </summary>
        /// <param name="rabbitMqOptions">The rabbit mq options.</param>
        public VendorStatusUpdateSender(RabbitMqConfig rabbitMqOptions)
        {
            hostname = rabbitMqOptions.Hostname;
            username = rabbitMqOptions.UserName;
            password = rabbitMqOptions.Password;
            queueName = rabbitMqOptions.QueueName;
            exchangeName = rabbitMqOptions.ExchangeName;
        }

        public void SendVendorStatus(VendorStatusList vendorStatus)
        {
            var factory = new ConnectionFactory() { HostName = hostname, UserName = username, Password = password };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                    channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);

                    var json = JsonConvert.SerializeObject(vendorStatus);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: exchangeName, routingKey: "", basicProperties: null, body: body);
                }
            }
        }
    }
}
