using AutoMapper;
using OnlineStoreMicroservices.Warehouse.Context.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.Warehouse.Features.Base
{
    public class CommandBase
    {
        protected readonly IWarehouseDbContext _context;
        protected readonly IMapper _mapper;

        public CommandBase(IWarehouseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
