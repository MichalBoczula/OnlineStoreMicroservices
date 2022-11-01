using AutoMapper;
using OnlineStoreMicroservices.AccountantsDepartment.Context.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Features.Base
{
    public class QueryBase
    {
        protected readonly IAccountantDbContext _context;
        protected readonly IMapper _mapper;

        public QueryBase(IAccountantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
