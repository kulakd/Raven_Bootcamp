using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using RavenAPI.Models;

namespace RavenAPI.Controllers
{
    public class MovieController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class MovieController : ControllerBase
        {
            private readonly IAsyncDocumentSession session;
            private readonly string collectionName = "movies/";

            public MovieController(IAsyncDocumentSession Session)
            {
                session = Session;
            }

            // GET: api/<ValuesController>
            [HttpGet]
            public async Task<List<Movie>> Get()
            {
                var movies = await session
                    .Query<Movie>()
                    .ToListAsync();
                return movies;
            }

            [HttpGet("{id}")]
            public async Task<Movie> Get(string id)
            {
                id = collectionName + id;
                var movies = await session.LoadAsync<Movie>(id);
                return movies;
            }

            // POST api/<ValuesController>
            [HttpPost]
            public async Task Post([FromBody] Movie newMovie)
            {
                await session.StoreAsync(newMovie);
                await session.SaveChangesAsync();
            }

            // PUT api/<ValuesController>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/<ValuesController>/5
            [HttpDelete("{id}")]
            public async Task Delete(string id)
            {
                session.Delete(id);
                await session.SaveChangesAsync();
            }
        }
    }
}
