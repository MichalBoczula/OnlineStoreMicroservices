using AutoMapper;
using OnlineStoreMicroservices.ShoppingCart.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
