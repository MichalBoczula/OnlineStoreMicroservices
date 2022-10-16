using MediatR;
using MessageBus.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineStoreMicroservices.DiscountCoupon.Context;
using OnlineStoreMicroservices.DiscountCoupon.Context.Abstract;
using OnlineStoreMicroservices.DiscountCoupon.Features.Command.ActivateCoupon;
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
    public class EventConsumerService : IHostedService
    {

        private readonly IServiceScopeFactory _scopeFactory;

        public EventConsumerService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<DiscountCouponDbContext>();
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                    var factory = new ConnectionFactory() { HostName = "localhost" };
                    using var connection = factory.CreateConnection();
                    using var channel = connection.CreateModel();

                    var consumer = new EventingBasicConsumer(channel);

                    while(!cancellationToken.IsCancellationRequested)
                    {
                        var message = string.Empty;

                        channel.BasicConsume(queue: "UpdateDiscountCoupon_DiscountCoupon",
                                           autoAck: true,
                                           consumer: consumer);

                        consumer.Received += async (sender, e) =>
                        {
                            var body = e.Body.ToArray();
                            message = Encoding.UTF8.GetString(body);
                            if (!string.IsNullOrWhiteSpace(message))
                            {
                                await mediator.Send(new ActivateCouponCommand() { IntegrationId = message });
                            }
                        };
                    }
                }
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
