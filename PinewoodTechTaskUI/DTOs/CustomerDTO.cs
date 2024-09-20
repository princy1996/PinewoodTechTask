namespace PinewoodTechTaskUI.DTOs
{
    public class CustomerDTO
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
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
