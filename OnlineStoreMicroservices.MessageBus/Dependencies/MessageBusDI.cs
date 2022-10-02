using MessageBus.Services;
using MessageBus.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.MessageBus.Dependencies
{
    public static class MessageBusDI
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services)
        {
            services.AddTransient<IMessageHandler, MessageHandler>();
            return services;
        }
    }
}
