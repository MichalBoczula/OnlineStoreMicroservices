using RabbitMQ.Client;
using System;
using System.Collections.Generic;

namespace MessageBus.Services.Interfaces
{
    public interface IMessageService
    {
        bool SendMessage(string message, Dictionary<string, object> header, string exchange);

        string ConsumeMessage(string queue);
    }
}
