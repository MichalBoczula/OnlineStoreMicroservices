using AutoMapper;
using OnlineStoreMicroservices.Warehouse.Context.Abstract;

namespace OnlineStoreMicroservices.Warehouse.Features.Base
{
    public class QueryBase
    {
        protected readonly IWarehouseDbContext _context;
        protected readonly IMapper _mapper;

        public QueryBase(IWarehouseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
