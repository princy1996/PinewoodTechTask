using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PinewoodTechAPI.Interfaces;

namespace PinewoodTechTaskAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public CustomerController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCustomer")]
        public Task<ActionResult<ICustomerDTO>> GetCustomer(int id)
        {
            
        }

        [HttpGet(Name = "GetCustomers")]
        public Task<ActionResult<IList<ICustomerDTO>>> GetCustomers()
        {
            
        }

        [HttpPost(Name = "PostCustomers")]
        public Task<IActionResult> PostCustomers([FromBody]ICustomerDTO newCustomer)
        {

        }

        [HttpPut(Name = "PutCustomer")]
        public Task<IActionResult> PutCustomer([FromBody]ICustomerDTO updateCustomer)
        {

        }

        [HttpDelete(Name = "DeleteCustomer")]
        public Task<IActionResult> DeleteCustomer(int id)
        {

        }
    }
}
