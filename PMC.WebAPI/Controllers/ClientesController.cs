using Microsoft.AspNetCore.Mvc;
using PMC.Core.Domain;
using PMC.Manager.Implementation;
using PMC.Manager.Interfaces;

namespace PMC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteManager _clienteManager;
        public ClientesController(IClienteManager clienteManager) 
        {
            _clienteManager = clienteManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await _clienteManager.GetAllClientsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok( await _clienteManager.GetClientByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            var novoCliente = await _clienteManager.InsertClientAsync(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut()]
        public async Task<IActionResult> Put(Cliente cliente)
        {
            var clienteAQtualizado = await _clienteManager.UpdateClientAsync(cliente);
            if(clienteAQtualizado == null)
            {
                return BadRequest("Cliente não encontrado");
            }

            return Ok(clienteAQtualizado);  
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteManager.DeleteClientAsync(id);
            return NoContent();
        }
    }
}
