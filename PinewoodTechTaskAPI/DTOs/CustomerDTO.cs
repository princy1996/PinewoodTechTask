using PinewoodTechAPI.Interfaces;

namespace PinewoodTechAPI.DTOs
{
    public class CustomerDTO : ICustomerDTO
    {
        public CustomerDTO()
        {
        }

        public CustomerDTO(int customerId, string firstName, string lastName, string email, int phoneNumber, string address, string city, string region, string postalCode, string country)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
        }
        public required int CustomerId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required int PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string Region { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
    }
}
