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
        public ClientesController(IClienteManager clienteManager) 
        {
            _clienteManager = clienteManager;
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
            return responseOK;
        }

        /// <summary>
        /// Retorna um cliente específico, através do Id.
        /// </summary>
        /// <param name="id" example="4">Id do cliente</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GenericResponse<Cliente>>> GetById(int id)
        {
            var cliente = await _clienteManager.GetClientByIdAsync(id);
            if (cliente == null)
            {
                var notFoundResponse = new GenericResponse<Cliente>(StatusCodes.Status404NotFound, false, "Cliente não encontrado", null);

                return notFoundResponse;
            }
            var okResponse = new GenericResponse<Cliente>(StatusCodes.Status200OK, true, null, cliente);
            return okResponse;
        }

        /// <summary>
        /// Insere um novo registro de cliente na base.
        /// </summary>
        /// <param name="newCliente"></param>
        [HttpPost]
        [ProducesResponseType(typeof(GenericResponse<NewClienteModelView>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GenericResponse<NewClienteModelView>>> Post(NewClienteModelView newCliente)
        {
            var insertedCliente = await _clienteManager.InsertClientAsync(newCliente);
            var newClienteInserted = CreatedAtAction(nameof(GetById), new { id = insertedCliente.Id }, insertedCliente);
            return new GenericResponse<NewClienteModelView>(StatusCodes.Status201Created, true, "Cliente cadastrado com sucesso.", newCliente);
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
                return new GenericResponse<Cliente>(StatusCodes.Status404NotFound, false, "Cliente não encontrado", null);
            }

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
                return new GenericResponse<string>(StatusCodes.Status204NoContent, true, "Cliente deletado com sucesso", null);
            } catch (Exception ex)
            {
                return new GenericResponse<string>(StatusCodes.Status500InternalServerError, false, "Erro ao deletar cliente.", ex.Message);
            }
        }
    }
}
