using Microsoft.AspNetCore.Mvc;
using PMC.Core.Domain;

namespace PMC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok( new List<Cliente>()
            {
                new Cliente()
                {
                    Id = 1,
                    Name = "João Pedro",
                    BirthDate = new DateTime(2001, 06, 02)
                },
                                new Cliente()
                {
                    Id = 2,
                    Name = "Nícolas",
                    BirthDate = new DateTime(2005, 10, 29)
                }
            });
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
