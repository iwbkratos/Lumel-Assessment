using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Helper;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/revenue")]
    [ApiController]
    public class RevenueController(IPaymentService _paymentService) : ControllerBase
    {
        [HttpGet("revenue")]
        public async Task<ActionResult<RevenueModel>> GetTotalRevenue([FromBody]TotalRevenue revenue)
        {
            var res = await _paymentService.GetRevernueByRange(revenue);

            if (res == null)
                throw new ApiException(417, "Something went wrong!", "");

            return StatusCode(200,res);
        }

    }
}
