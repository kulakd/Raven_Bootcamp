namespace RavenAPI.Models
{
    public class Movie
    {
        public string Id { get; set; }
        public MovieDetails MovieDetails { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public DateTime Premiere { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }

    public class MovieDetails
    {
        public int Amount { get; set; }
        public int Borrowed { get; set; }

        public int Available { get => Amount - Borrowed; }
    }
}
