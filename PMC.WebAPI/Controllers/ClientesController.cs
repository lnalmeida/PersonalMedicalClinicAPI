using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMC.Core.Domain;
using PMC.Core.Shared.ModelViews;
using PMC.Manager.Implementation;
using PMC.Manager.Interfaces;
using PMC.WebAPI.Responses;
using System.Net;

namespace PMC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteManager _clienteManager;
        private readonly ILogger<ClientesController> _logger;
        public ClientesController(IClienteManager clienteManager, ILogger<ClientesController> logger) 
        {
            _clienteManager = clienteManager;
            _logger = logger;
        }

        /// <summary>
        /// Retorna todos os clientes cadastrados na base.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(GenericResponse<List<Cliente>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GenericResponse<List<Cliente>>>> Get()
        {
            var clientes = await _clienteManager.GetAllClientsAsync();
            var responseOK = new GenericResponse<List<Cliente>>(StatusCodes.Status200OK, true, null, clientes.ToList());
            _logger.LogInformation($"[GET] - Clientes retornados com sucesso.");
            return responseOK;
        }

        /// <summary>
        /// Retorna um cliente específico, através do Id.
        /// </summary>
        /// <param name="id" example="4">Id do cliente</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GenericResponse<Cliente>>> GetById(int id)
        {
            var cliente = await _clienteManager.GetClientByIdAsync(id);
            if (cliente == null)
            {
                _logger.LogInformation($"[GET] - Erro - Cliente com o´Id: {id} não encontrado");
                return new GenericResponse<Cliente>(StatusCodes.Status404NotFound, false, "Cliente não encontrado", null);
            }
            _logger.LogInformation($"[GET] - Cliente com Id: {cliente.Id} encontrado");
            return new GenericResponse<Cliente>(StatusCodes.Status200OK, true, null, cliente);
        }

        /// <summary>
        /// Insere um novo registro de cliente na base.
        /// </summary>
        /// <param name="newCliente"></param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GenericResponse<Cliente>>> Post(NewClienteModelView newCliente)
        {
            var insertedCliente = await _clienteManager.InsertClientAsync(newCliente);
            var newClienteInserted = CreatedAtAction(nameof(GetById), new { id = insertedCliente.Id }, insertedCliente);
            _logger.LogInformation($"[POST] - Cliente cadastrado com sucesso");
            return new GenericResponse<Cliente>(StatusCodes.Status201Created, true, "Cliente cadastrado com sucesso.", insertedCliente);
        }

        /// <summary>
        /// Atualiza o registro de um cliente específico, buscando pelo Id.
        /// </summary>
        /// <param name="cliente"></param>
        [HttpPut()]
        [ProducesResponseType(typeof(GenericResponse<Cliente>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GenericResponse<Cliente>>> Put(UpdateClienteModelView cliente)
        {
            var clienteAtualizado = await _clienteManager.UpdateClientAsync(cliente);
            if(clienteAtualizado == null)
            {
                _logger.LogInformation($"[PUT] - Erro - Cliente com Id: {cliente.Id} não encontrado");
                return new GenericResponse<Cliente>(StatusCodes.Status404NotFound, false, "Cliente não encontrado", null);
            }
            _logger.LogInformation($"[PUT] -  Cliente Atualizado com sucesso.");
            return new GenericResponse<Cliente>(StatusCodes.Status200OK, true, "Cliente atualizado com sucesso.", clienteAtualizado);  
        }

        /// <summary>
        /// Deleta o registro de um cliente específico, buscando pelo Id.
        /// </summary>
        /// <param name="id" example="11" >Id do cliente</param>
        /// <remarks>Ao excluir um cliente, ele será permanentemente excluído da base.</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(GenericResponse<string>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GenericResponse<string>>> Delete(int id)
        {
            try
            {
                await _clienteManager.DeleteClientAsync(id);
                _logger.LogInformation($"[DELETE] - Cliente deletado com sucesso.");
                return new GenericResponse<string>(StatusCodes.Status204NoContent, true, "Cliente deletado com sucesso", null);
            } catch (Exception ex)
            {
                _logger.LogInformation($"[DELETE] - Erro ao deletar cliente: {ex.Message}");
                return new GenericResponse<string>(StatusCodes.Status500InternalServerError, false, "Erro ao deletar cliente.", ex.Message);
            }
        }
    }
}
