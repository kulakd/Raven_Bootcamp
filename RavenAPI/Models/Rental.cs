namespace RavenAPI.Models
{
    public class Rental
    {
        public string Id { get; set; }
        public string MovieId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
