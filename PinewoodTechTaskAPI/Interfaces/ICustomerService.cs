using PinewoodTechAPI.Interfaces;

namespace PinewoodTechTaskAPI.Interfaces
{
    public interface ICustomerService
    {
        public Task<object> GetCustomer(int id);
        public Task<object> GetCustomers();
        public Task<object> PutCustomer(int id, ICustomerDTO updateCustomer);
        public Task<object> PostCustomer(ICustomerDTO newCustomer);
        public Task<object> DeleteCustomer(int id);
    }
}
