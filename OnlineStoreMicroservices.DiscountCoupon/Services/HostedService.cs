using MediatR;
using Microsoft.Extensions.Hosting;
using OnlineStoreMicroservices.DiscountCoupon.Context.Abstract;
using OnlineStoreMicroservices.DiscountCoupon.Features.Command.DeactivateCoupon;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Services
{
    public class HostedService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            var message = string.Empty;

            channel.BasicConsume(queue: "UpdateDiscountCoupon_DiscountCoupon",
                               autoAck: true,
                               consumer: consumer);

            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                message = Encoding.UTF8.GetString(body);
            };

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
