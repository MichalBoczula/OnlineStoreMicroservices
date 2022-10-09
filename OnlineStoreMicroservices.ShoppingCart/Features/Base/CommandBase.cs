using AutoMapper;
using OnlineStoreMicroservices.ShoppingCart.Context.Abstract;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Base
{
    public class CommandBase
    {
        protected readonly IShoppingCartDbContext _context;
        protected readonly IMapper _mapper;

        public CommandBase(IShoppingCartDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
