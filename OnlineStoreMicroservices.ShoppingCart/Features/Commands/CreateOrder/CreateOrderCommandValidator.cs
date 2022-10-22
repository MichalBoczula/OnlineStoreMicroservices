using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace OnlineStoreMicroservices.ShoppingCart.Features.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            var couponsIds = new List<string>
            {
                "e0cfebf1-5fa6-49d0-a726-c5c4b2ce3de9",
                "3ed3adc6-7416-4d63-9048-9d1b92554c21",
                "fd918135-bcf1-4310-8b20-81365ad80862"
            };

            RuleFor(x => x.ShoppingCart.DiscountCouponId).Custom((x, context) =>
            {
                if(!string.IsNullOrWhiteSpace(x))
                {
                    if(couponsIds.Contains(x))
                    {
                        context.AddFailure(new ValidationFailure("ShoppingCart.DiscountCouponId", "DiscountCoupon doesn't exist."));
                    }
                }
            });
        }
    }
}
