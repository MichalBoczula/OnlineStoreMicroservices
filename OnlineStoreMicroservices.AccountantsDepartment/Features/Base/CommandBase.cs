using AutoMapper;
using OnlineStoreMicroservices.AccountantsDepartment.Context.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Features.Base
{
    public class CommandBase
    {
        protected readonly IAccountantDbContext _context;
        protected readonly IMapper _mapper;

        public CommandBase(IAccountantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
