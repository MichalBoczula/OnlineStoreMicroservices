using AutoMapper;
using OnlineStoreMicroservices.ShoppingCart.Context.Abstract;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Base
{
    public class QueryBase
    {
        protected readonly IShoppingCartDbContext _context;
        protected readonly IMapper _mapper;

        public QueryBase(IShoppingCartDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
