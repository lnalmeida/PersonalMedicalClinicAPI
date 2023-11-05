using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMC.Core.Domain;
using PMC.Core.Shared.ModelViews;
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

        /// <summary>
        /// Retorna todos os clientes cadastrados na base.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok( await _clienteManager.GetAllClientsAsync());
        }

        /// <summary>
        /// Retorna um cliente específico, através do Id.
        /// </summary>
        /// <param name="id" example="4">Id do cliente</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok( await _clienteManager.GetClientByIdAsync(id));
        }

        /// <summary>
        /// Insere um novo registro de cliente na base.
        /// </summary>
        /// <param name="newCliente"></param>
        [HttpPost]
        [ProducesResponseType(typeof(NewClienteModelView), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NewClienteModelView newCliente)
        {
            var insertedCliente = await _clienteManager.InsertClientAsync(newCliente);
            return CreatedAtAction(nameof(GetById), new { id = insertedCliente.Id }, insertedCliente);
        }

        /// <summary>
        /// Atualiza o registro de um cliente específico, buscando pelo Id.
        /// </summary>
        /// <param name="cliente"></param>
        [HttpPut()]
        [ProducesResponseType(typeof(UpdateClienteModelView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(UpdateClienteModelView cliente)
        {
            var clienteAQtualizado = await _clienteManager.UpdateClientAsync(cliente);
            if(clienteAQtualizado == null)
            {
                return BadRequest("Cliente não encontrado");
            }

            return Ok(clienteAQtualizado);  
        }

        /// <summary>
        /// Deleta o registro de um cliente específico, buscando pelo Id.
        /// </summary>
        /// <param name="id" example="11" >Id do cliente</param>
        /// <remarks>Ao excluir um cliente, ele será permanentemente excluído da base.</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteManager.DeleteClientAsync(id);
            return NoContent();
        }
    }
}
