using AutoMapper;
using MessageBus.Services.Interfaces;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Base
{
    public class NotificationBase
    {
        protected readonly IMessageService _messageService;
        protected readonly IMapper _mapper;

        public NotificationBase(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }
    }
}
