using AutoMapper;
using OnlineStoreMicroservices.ShoppingCart.Context.Abstract;
using OnlineStoreMicroservices.ShoppingCart.Service.Abstract;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Base
{
    public class QueryBase
    {
        protected readonly IShoppingCartDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly ISynchNotificationService _synchNotificationService;

        public QueryBase(ISynchNotificationService synchNotificationService)
        {
            _synchNotificationService = synchNotificationService;
        }

        public QueryBase(IShoppingCartDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
