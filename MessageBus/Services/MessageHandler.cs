using MessageBus.Services.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBus.Services
{
    internal class MessageHandler : IMessageHandler
    {
        public MessageHandler()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var exchange = "headerExchange";

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange, ExchangeType.Headers, true, false, null);

            var message = new { Name = "add, update, get", Message = "Triple actions bro" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            var props = channel.CreateBasicProperties();
            props.Headers = new Dictionary<string, object>
            {
                { "UpdateCoupon", "UpdateCoupon" },
            };
        }

        public bool SendMessage(string message)
        {

            return true;
        }

        public bool ConsumeMessage(string message)
        {

            return true;
        }


    }
}
