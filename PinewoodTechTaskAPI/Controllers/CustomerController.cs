using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PinewoodTechAPI.Interfaces;
using PinewoodTechTaskAPI.Interfaces;

namespace PinewoodTechTaskAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<WeatherForecastController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet(Name = "GetCustomer")]
        public ActionResult<ICustomerDTO> GetCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);
            
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpGet(Name = "GetCustomers")]
        public ActionResult<IList<ICustomerDTO>> GetCustomers()
        {
            var customer = _customerService.GetCustomers();

            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost(Name = "PostCustomers")]
        public ActionResult PostCustomers([FromBody]ICustomerDTO newCustomer)
        {
            var customer = _customerService.PostCustomer(newCustomer);

            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPut(Name = "PutCustomer")]
        public ActionResult PutCustomer(int id,[FromBody]ICustomerDTO updateCustomer)
        {
            var customer = _customerService.PutCustomer(id, updateCustomer);

            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpDelete(Name = "DeleteCustomer")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);

            return customer == null ? NotFound() : Ok(customer);
        }
    }
}
