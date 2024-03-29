﻿using MediatR;
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
        private DiscountCouponDbContext dbContext;
        private IMediator mediator;
        private IConnection connection;
        private IModel channel;
        private EventingBasicConsumer consumer;

        public EventConsumerService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            var scope = _scopeFactory.CreateScope();
            dbContext = scope.ServiceProvider.GetRequiredService<DiscountCouponDbContext>();
            mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            consumer = new EventingBasicConsumer(channel);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                channel.BasicConsume(queue: "UpdateDiscountCoupon_DiscountCoupon",
                                   autoAck: true,
                                   consumer: consumer);

                consumer.Received += async (sender, e) =>
                {
                    var body = e.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        await mediator.Send(new DeactivateCouponCommand() { IntegrationId = message });
                    }
                };
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            connection.Dispose();
            channel.Dispose();
            dbContext.Dispose();
            return Task.CompletedTask;
        }
    }
}
