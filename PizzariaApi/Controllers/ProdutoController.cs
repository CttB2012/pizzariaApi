using Entidades;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

namespace PizzariaApi.Controllers
{
    [Route("PizzariaApi/[Controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public const string NAO_ENCONTRADO = "Produto nao encontrado na base de dados";
        public const string PRODUTO_EXCLUIDO = "Produto excluído da base de dados";
        public const string PRODUTO_ATUALIZADO = "Produto atualizado com sucesso";

        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost("CadastraNovoProduto")]
        public IActionResult CadastrarNovoProduto(Produto produto)
        {
            var produtoCadastrado = _produtoService.CadastrarNovoProduto(produto);
            return Ok(produtoCadastrado);
        }

        [HttpGet("ListaTodosProdutos")]
        public IActionResult ListarTodosProdutos()
        {
            var listaDeProdutos = _produtoService.ListarTodosProdutos();
            return Ok(listaDeProdutos);
        }

        [HttpGet("ListaProdutoPelaId/{id}")]
        public IActionResult ListarProdutoPorId(int id)
        {
            var produtoPorId = _produtoService.ListarProdutoPorId(id);
            IActionResult resultado = produtoPorId != null ? Ok(produtoPorId) : NotFound(NAO_ENCONTRADO);

            return resultado;
        }

        [HttpDelete("ExcluiProdutoPelaId/{id}")]
        public IActionResult ExcluirProduto(int id)
        {
            var produtoParaExcluir = _produtoService.ExcluirProduto(id);
            IActionResult resultado = produtoParaExcluir == false ? NotFound(NAO_ENCONTRADO) : Ok(PRODUTO_EXCLUIDO);

            return resultado;
        }

        [HttpPut("AtualizaProduto/{id}")]
        public IActionResult AtualizarProduto(Produto produto, int id)
        {
            var produtoAtualizado = _produtoService.AtualizarProduto(produto, id);
            IActionResult resultado = produtoAtualizado != null ? Ok(PRODUTO_ATUALIZADO) : NotFound(NAO_ENCONTRADO);

            return resultado;
        }

    }
}
