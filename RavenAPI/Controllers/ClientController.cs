using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using RavenAPI.Models;

namespace RavenAPI.Controllers
{
    public class ClientController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ClientController : ControllerBase
        {
            private readonly IAsyncDocumentSession session;
            private readonly string collectionName = "clients/";

            public ClientController(IAsyncDocumentSession Session)
            {
                session = Session;
            }

            // GET: api/<EmployeeController>
            [HttpGet]
            public async Task<List<Client>> Get()
            {
                var clients = await session
                    .Query<Client>()
                    .ToListAsync();
                return clients;
            }

            // GET api/<EmployeeController>/5
            [HttpGet("{id}")]
            public async Task<Client> Get(string id)
            {
                id = collectionName + id;
                var client = await session.LoadAsync<Client>(id);
                return client;
            }

            // POST api/<EmployeeController>
            [HttpPost]
            public async void Post([FromBody] Client newClient)
            {
                await session.StoreAsync(newClient);
                await session.SaveChangesAsync();
            }

            // PUT api/<EmployeeController>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/<EmployeeController>/5
            [HttpDelete("{id}")]
            public async void Delete(string id)
            {
                id = collectionName + id;
                session.Delete(id);
                await session.SaveChangesAsync();
            }
        }
    }
}
