using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PinewoodTechTaskUI.Config;
using PinewoodTechTaskUI.DTOs;

namespace PinewoodTechTaskUI.Pages
{
    public class UpdateModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfig _config;

        [BindProperty]
        public CustomerDTO customer { get; set; }

        public UpdateModel(ILogger<IndexModel> logger, IConfig config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerTMP = await GetCustomer(id);

            if(customer == null)
            {
                return NotFound();
            }
            customer = customerTMP;
            return Page();
        }

        public async Task<CustomerDTO> GetCustomer(int? id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(_config.ConnectionString + $"GetCustomer/{id}");
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadAsAsync<CustomerDTO>();
                return customer;
            }
            else
            {
                ViewData["Message"] = response.ReasonPhrase;
            }

            return customer;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PutAsJsonAsync<CustomerDTO>(_config.ConnectionString + $"PutCustomer/{id}", customer);
            if (response.IsSuccessStatusCode)
            {
                ViewData["Message"] = "Update Successful";
            }
            else
            {
                ViewData["Message"] = response.ReasonPhrase;
            }

            return Page();
        }
    }
}
