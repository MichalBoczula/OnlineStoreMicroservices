using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBus.Services.Interfaces
{
    interface IMessageHandler
    {
        bool SendMessage(string message);

        bool ConsumeMessage(string message);
    }
}
