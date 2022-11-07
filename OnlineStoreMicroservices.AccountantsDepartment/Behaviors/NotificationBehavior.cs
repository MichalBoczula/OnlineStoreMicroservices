using OnlineStoreMicroservices.AccountantsDepartment.Features.Commands.SaveUserProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.AccountantsDepartment.Behaviors
{
    public class NotificationBehavior<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly IMediator _mediator;

        public NotificationBehavior(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            
        }
    }
}
