using Microsoft.AspNetCore.Mvc;
using OnlineStoreMicroservices.DiscountCoupon.Features.Command.ActivateCoupon;
using OnlineStoreMicroservices.DiscountCoupon.Features.Command.DeactivateCoupon;
using OnlineStoreMicroservices.DiscountCoupon.Features.Queries;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.DiscountCoupon.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCouponController : BaseController
    {
        [HttpGet()]
        public async Task<ActionResult> GetDiscountCouponsAsync()
        {
            var result = await Mediator.Send(new GetCouponsQuery());
            return Ok(result);
        }

        [HttpPost("activate")]
        public async Task<ActionResult> ActivateCouponByIdAsync([FromBody] string intergationId)
        {
            var result = await Mediator.Send(new ActivateCouponCommand() { IntegrationId = intergationId });
            return Ok(result);
        }

        [HttpPost("deactivate")]
        public async Task<ActionResult> DeactivateCouponByIdAsync([FromBody] string intergationId)
        {
            var result = await Mediator.Send(new DeactivateCouponCommand() { IntegrationId = intergationId });
            return Ok(result);
        }
    }
}
