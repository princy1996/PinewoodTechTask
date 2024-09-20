using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PinewoodTechTaskUI.Config;
using PinewoodTechTaskUI.DTOs;
using System.Net.Http;

namespace PinewoodTechTaskUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfig _config;

        public List<CustomerDTO> customers = new List<CustomerDTO>();

        public IndexModel(ILogger<IndexModel> logger, IConfig config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task OnGetAsync()
        {
            await GetCustomers();
        }

        public async Task<IActionResult> GetCustomers()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(_config.ConnectionString + "GetCustomers");
            if (response.IsSuccessStatusCode) 
            {
                customers = await response.Content.ReadAsAsync<List<CustomerDTO>>();
            }
            else
            {
                ViewData["Error"] = response.ReasonPhrase;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.DeleteAsync(_config.ConnectionString + $"DeleteCustomer/{id}");
            if (response.IsSuccessStatusCode)
            {
                ViewData["Delete"] = "Delete Successful";
                await GetCustomers();

            }
            else
            {
                ViewData["Delete"] = response.ReasonPhrase;
            }

            return Page();
        }
    }
}
