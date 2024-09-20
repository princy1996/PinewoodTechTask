using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PinewoodTechTaskUI.Config;
using PinewoodTechTaskUI.DTOs;
using System.Xml.Linq;

namespace PinewoodTechTaskUI.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly IConfig _config;

        [BindProperty]
        public CustomerDTO newCustomer {  get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
        public CreateModel(ILogger<CreateModel> logger, IConfig config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync<CustomerDTO>(_config.ConnectionString + "PostCustomers", newCustomer);
            if (response.IsSuccessStatusCode)
            {
                ViewData["Message"] = $"New Customer {newCustomer.FirstName} {newCustomer.LastName} Added";
            }
            else
            {
                ViewData["Message"] = response.ReasonPhrase;
            }
            return Page();

        }
    }
}
