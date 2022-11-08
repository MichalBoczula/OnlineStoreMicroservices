using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineStoreMicroservices.Warehouse.Context;
using OnlineStoreMicroservices.Warehouse.Features.Commands.SaveUserProducts;
using OnlineStoreMicroservices.Warehouse.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Services
{
    public class EventConsumerService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private WarehouseDbContext dbContext;
        private IMediator mediator;
        private IConnection connection;
        private IModel channel;
        private IMapper mapper;
        private EventingBasicConsumer consumer;

        public EventConsumerService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            var scope = _scopeFactory.CreateScope();
            dbContext = scope.ServiceProvider.GetRequiredService<WarehouseDbContext>();
            mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            consumer = new EventingBasicConsumer(channel);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() =>
            {
                channel.BasicConsume(queue: "UpdateOrder_Warehouse",
                                   autoAck: true,
                                   consumer: consumer);

                consumer.Received += async (sender, e) =>
                {
                    var body = e.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var customerBasketExternal = JsonSerializer.Deserialize<CustomerBasketExternal>(message);
                    var customerToCreation = mapper.Map<CustomerBasketExternal, UserBasketForCreationDto>(customerBasketExternal);
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        await mediator.Send(new SaveUserProductsCommand() { UserBasket = customerToCreation });
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
