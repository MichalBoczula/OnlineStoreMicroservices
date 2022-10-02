using MessageBus.Services.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBus.Services
{
    internal class MessageHandler : IMessageHandler
    {
        private readonly IModel _channel;
        private readonly EventingBasicConsumer _consumer;
        private const string _exchange = "OnlineStoreMicroServicesExchange";

        public MessageHandler()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            _channel = channel;
            _consumer = new EventingBasicConsumer(channel);

            var discountCouponHeader = new Dictionary<string, object>
            {
                { "UpdateDiscountCoupon", "DiscountCoupon" },
            };
            var shoppingCartHeader = new Dictionary<string, object>
            {
                { "UpdateDiscountCoupon", "ShoppingCart" },
            };

            channel.ExchangeDeclare(_exchange, ExchangeType.Headers, true, false, null);
            channel.QueueDeclare("UpdateDiscountCoupon_DiscountCoupon", true, false, false);
            channel.QueueDeclare("UpdateDiscountCoupon_ShoppingCart", true, false, false);
            channel.QueueBind("UpdateDiscountCoupon_DiscountCoupon", _exchange, string.Empty, discountCouponHeader);
            channel.QueueBind("UpdateDiscountCoupon_ShoppingCart", _exchange, string.Empty, shoppingCartHeader);
        }

        public bool SendMessage(string message, IBasicProperties props)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            var response = true;

            try
            {
                _channel.BasicPublish(exchange: _exchange,
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
            string message = string.Empty;

            try
            {
                _channel.BasicConsume(queue: queue,
                                    autoAck: true,
                                    consumer: _consumer);

                _consumer.Received += (sender, e) =>
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
