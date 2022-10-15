using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineStoreMicroservices.DiscountCoupon.Context.Abstract;
using OnlineStoreMicroservices.DiscountCoupon.Features.Command.DeactivateCoupon;
using OnlineStoreMicroservices.DiscountCoupon.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEventConsumer _eventConsumer;

        public Worker(ILogger<Worker> logger, IEventConsumer eventConsumer)
        {
            _logger = logger;
            _eventConsumer = eventConsumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
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

                    if (!string.IsNullOrEmpty(message))
                    {
                        Task.Run(async () =>
                        {
                            await _eventConsumer.Test(message);
                        });
                    }
                };
            }
        }
    }
}
