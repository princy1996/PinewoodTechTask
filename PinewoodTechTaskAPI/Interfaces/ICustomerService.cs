namespace PinewoodTechTaskAPI.Interfaces
{
    public interface ICustomerService
    {
        public Task GetCustomer(int id);
        public Task GetCustomers();
        public Task PutCustomer(int id);
        public Task PostCustomer();
        public Task DeleteCustomer(int id);
    }
}
