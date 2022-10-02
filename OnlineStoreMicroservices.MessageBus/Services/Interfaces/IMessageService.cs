using RabbitMQ.Client;
using System;

namespace MessageBus.Services.Interfaces
{
    public interface IMessageHandler
    {
        bool SendMessage(string message, IBasicProperties props);

        string ConsumeMessage(string queue);
    }
}
