using MessageBus.Services.Interfaces;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Base
{
    public class NotificationBase
    {
        protected readonly IMessageService messageService;

        public NotificationBase(IMessageService messageService)
        {
            this.messageService = messageService;
        }
    }
}
