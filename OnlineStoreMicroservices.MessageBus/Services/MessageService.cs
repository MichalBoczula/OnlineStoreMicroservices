using MessageBus.Services.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBus.Services
{
    internal class MessageService : IMessageService
    {
        private readonly ConnectionFactory _factory;
        private const string _exchange = "OnlineStoreMicroServicesExchange";

        public MessageService()
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            var updateOrder = new Dictionary<string, object>
            {
                { "Order", "UpdateOrder" },
            };
            var shoppingCartHeader = new Dictionary<string, object>
            {
                { "UpdateDiscountCoupon", "coupon" },
            };
            var correlation = new Dictionary<string, object>
             {
                 { "MachineState", "Correlation" },
             };

            channel.ExchangeDeclare(_exchange, ExchangeType.Headers, true, false, null);
            channel.QueueDeclare("UpdateDiscountCoupon_DiscountCoupon", true, false, false);
            channel.QueueDeclare("UpdateOrder_AccountantsDepartment", true, false, false);
            channel.QueueDeclare("UpdateOrder_Warehouse", true, false, false);
            channel.QueueDeclare("SendInformationAboutOrder", true, false, false);
            channel.QueueBind("UpdateDiscountCoupon_DiscountCoupon", _exchange, string.Empty, shoppingCartHeader);
            channel.QueueBind("UpdateOrder_AccountantsDepartment", _exchange, string.Empty, updateOrder);
            channel.QueueBind("UpdateOrder_Warehouse", _exchange, string.Empty, updateOrder);
            channel.QueueBind("SendInformationAboutOrder", _exchange, string.Empty, correlation);
        }

        public bool SendMessage(string message, Dictionary<string, object> header, string exchange)
        {
            var body = message is string ?
                Encoding.UTF8.GetBytes(message) :
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            
            var response = true;

            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            var props = channel.CreateBasicProperties();
            props.Headers = header;

            try
            {
                channel.BasicPublish(exchange: exchange,
                            routingKey: string.Empty,
                            basicProperties: props,
                            body: body);
            }
            catch (Exception ex)
            {
                response = false;
            }

            return response;
        }

        public string ConsumeMessage(string queue)
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            string message = string.Empty;

            try
            {
                channel.BasicConsume(queue: queue,
                                    autoAck: true,
                                    consumer: consumer);

                consumer.Received += (sender, e) =>
                {
                    var body = e.Body.ToArray();
                    message = Encoding.UTF8.GetString(body);
                };
            }
            catch (Exception ex)
            {

            }

            return message;
        }
    }
}
