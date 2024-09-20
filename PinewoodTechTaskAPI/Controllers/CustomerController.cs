using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PinewoodTechAPI.DTOs;
using PinewoodTechAPI.Interfaces;
using PinewoodTechTaskAPI.Interfaces;

namespace PinewoodTechTaskAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet]
        [Route("Api/[controller]/GetCustomer/{id}")]
        public ActionResult<ICustomerDTO> GetCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);
            switch (customer.Result)
            {
                case ICustomerDTO result:
                    return Ok(result);
                default:
                    return BadRequest(customer.Result);
            }
        }

        [HttpGet]
        [Route("Api/[controller]/GetCustomers")]
        public ActionResult<IList<CustomerDTO>> GetCustomers()
        {
            var customer = _customerService.GetCustomers();
            switch (customer.Result)
            {
                case IList<CustomerDTO> result:
                    return Ok(result);
                default:
                    return BadRequest(customer.Result);
            }
        }

        [HttpPost]
        [Route("Api/[controller]/PostCustomers")]
        public ActionResult PostCustomer([FromBody]CustomerDTO newCustomer)
        {
            var customer = _customerService.PostCustomer(newCustomer);

            switch (customer.Result)
            {
                case int result:
                    return Ok($"Number of rows changed: {result}. Opperation Successful");
                default:
                    return BadRequest(customer.Result);
            }
        }

        [HttpPut]
        [Route("Api/[controller]/PutCustomer/{id}")]
        public ActionResult PutCustomer(int id,[FromBody]CustomerDTO updateCustomer)
        {
            var customer = _customerService.PutCustomer(id, updateCustomer);

            switch (customer.Result)
            {
                case int result:
                    return Ok($"id: {id} has been updated");
                default:
                    return BadRequest(customer.Result);
            }
        }

        [HttpDelete]
        [Route("Api/[controller]/DeleteCustomer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.DeleteCustomer(id);

            switch (customer.Result)
            {
                case int result:
                    return Ok($"Number of rows deleted: {result}. Delete Successful");
                default:
                    return BadRequest(customer.Result);
            }
        }
    }
}
