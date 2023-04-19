namespace RavenAPI.Models
{
    public class Client
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Rental Rental { get; set; }
    }
}
