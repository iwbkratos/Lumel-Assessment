using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebApplication1.Dto;
using WebApplication1.Helper;
using WebApplication1.Repositories;
using WebApplication1.Services;


namespace WebApplication1.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController(IOrderService _order) : ControllerBase
    {
        

        [HttpPost("add")]
        public async Task<ActionResult<bool>>  AddOrder([FromForm]IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please upload a valid CSV file.");

            try
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<AddOrder>().ToList();

                    var res = await  _order.AddOrder(records);
                    
                    if(res)
                    return StatusCode(200, $"Success!");

                    return StatusCode(500, $"Internal server error");
                }
            }
            catch(Exception e) {
                throw new Exception("Something went wrong!");
            }
        }

    }
}
