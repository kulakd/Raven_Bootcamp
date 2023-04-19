using Raven.Client.Documents.Indexes;
using RavenAPI.Models;

namespace RavenAPI.Data
{
    public class MoviesById : AbstractIndexCreationTask<Movie>
    {
        public MoviesById()
        {
            Map = (movies) =>
                from Movie
                in movies
                select new
                {
                    Id = Movie.Id,
                    Title = Movie.Title,
                    Director = Movie.Director,
                    Copies = Movie.MovieDetails.Available
                };
        }
    }
}
