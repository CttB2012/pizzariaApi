using Entidades;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace PizzariaApi.Controllers
{

    [Route("PizzariaApi/[Controller]")]
    [ApiController]
    public class EnderecoClienteController : ControllerBase
    {
        public const string NAO_ENCONTRADO = "Endereco nao encontrado";
        public const string ENDERECO_EXCLUIDO = "Endereco excluido com sucesso";
        public const string ENDERECO_ATUALIZADO = "Endereco atualizado com sucesso";

        private readonly IEnderecoClienteService _enderececoClienteService;

        public EnderecoClienteController(IEnderecoClienteService enderecoClienteService)
        {
            _enderececoClienteService = enderecoClienteService;
        }
        [HttpPost("IncluiNovoEndereco")]
        public IActionResult IncluirNovoEndereco(EnderecoCliente enderecoCliente)
        {
            var novoEndereco = _enderececoClienteService.IncluirNovoEndereco(enderecoCliente);
            return Ok(novoEndereco);
        }

        [HttpGet("ListaTodosEnderecos")]
        public IActionResult ListarEnderecos()
        {
            var enderecos = _enderececoClienteService.ListarEnderecos();
            return Ok(enderecos);
        }

        [HttpGet("ListaEnderecoPelaId/{id}")]
        public IActionResult ListarEnderecoPelaId(int id)
        {
            var enderecoEncontrado = _enderececoClienteService.ListarEnderecoPelaId(id);
            IActionResult resultado = enderecoEncontrado != null ? Ok(enderecoEncontrado) : NotFound(NAO_ENCONTRADO);
            
            return Ok(resultado);
        }

        [HttpDelete("ExcluiEndereco/{id}")]
        public IActionResult ExcluirEndereco(int id)
        {
            var enderecoExcluido = _enderececoClienteService.ExcluirEndereco(id);

            IActionResult resultado = enderecoExcluido == false ? NotFound(NAO_ENCONTRADO) : Ok(ENDERECO_EXCLUIDO);
            return Ok(resultado);
        }

        [HttpPut("AtualizaEndereco/{id}")]
        public IActionResult AtualizarEndereco(EnderecoCliente endereco, int id)
        {
            var enderecoAtualizado = _enderececoClienteService.AtualizarEndereco(endereco, id);
            IActionResult resultado = enderecoAtualizado != null ? Ok(ENDERECO_ATUALIZADO) : NotFound(NAO_ENCONTRADO);
            return resultado;
        }
    }
}
