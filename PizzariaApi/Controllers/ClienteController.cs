using Entidades;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace PizzariaApi.Controllers
{
    [Route("PizzariaApi/[Controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public const string NAO_ENCONTRADO = "Cliente nao encontrado na base de dados";
        public const string CLIENTE_EXCLUIDO = "Cliente excluido com sucesso";
        public const string CLIENTE_ATUALIZADO = "Cliente atualizado com sucesso";

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("CadastraNovoCliente")]
        public IActionResult CadastrarNovoCliente(Cliente cliente)
        {
            var clienteCadastrado = _clienteService.CadastrarNovoCliente(cliente);
            return Ok(clienteCadastrado);

        }

        [HttpGet("ListaTodosClientes")]
        public IActionResult ListaTodosClientes()
        {
            var listaDeClientes = _clienteService.ListaTodosClientes();
            return Ok(listaDeClientes);
        }

        [HttpGet("ListaClientePelaId/{id}")]
        public IActionResult ListaClientePorId(int id)
        {
            var clientePorId = _clienteService.ListaClientePorId(id);
            IActionResult resultado = clientePorId != null ? Ok(clientePorId) : NotFound(NAO_ENCONTRADO);

            return Ok(resultado);
        }

        [HttpDelete("ExcluiClientePelaId/{id}")]
        public IActionResult ExcluiClientePelaId(int id)
        {
            var usuarioParaExcluir = _clienteService.ExcluiClientePelaId(id);

            IActionResult resultado = usuarioParaExcluir == false ?  NotFound(NAO_ENCONTRADO) : Ok(CLIENTE_EXCLUIDO);

            return resultado;
        }

        [HttpPut("AtualizaCliente/{id}")]
        public IActionResult AtualizaCliente(Cliente cliente, int id)
        {
            var clienteAtualizado = _clienteService.AtualizaCliente(cliente, id);
            IActionResult resultado = clienteAtualizado != null ? Ok(CLIENTE_ATUALIZADO) : NotFound(NAO_ENCONTRADO);

            return resultado;
        }
    }
}
