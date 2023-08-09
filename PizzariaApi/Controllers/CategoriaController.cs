using Entidades;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

namespace PizzariaApi.Controllers
{
    [Route("PizzariaApi/[Controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public const string NAO_ENCONTRADA = "Categoria nao encontrada. Verifique a informacao fornecida";
        public const string CATEGORIA_EXCLUIDA = "Categoria excluida";
        public const string CATEGORIA_ATUALIZADA = "Categoria atualizada";
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService= categoriaService;
        }

        [HttpPost("CadastraNovaCategoria")]
        public IActionResult CadastrarNovaCategoria(Categoria categoria)
        {
            var categoriaCadastrada = _categoriaService.CadastrarNovaCategoria(categoria);
            return Ok(categoriaCadastrada);
        }

        [HttpGet("ListaTodasCategorias")]
        public IActionResult ListarTodasCategorias()
        {
            var listaDeCategorias = _categoriaService.ListarTodasCategorias();
            return Ok(listaDeCategorias);
        }

        [HttpGet("ListaCategoriaPelaId/{id}")]
        public IActionResult ListarCategoriaPorId(int id)
        {
            var categoriaPorId = _categoriaService.ListarCategoriaPorId(id);
            IActionResult resultado = categoriaPorId != null ? Ok(categoriaPorId) : NotFound(NAO_ENCONTRADA);
            return resultado;
        }

        [HttpDelete("ExcluiCategoria/{id}")]
        public IActionResult ExcluirCategoria(int id)
        {
            var categoriaExcluida = _categoriaService.ExcluirCategoria(id);
            IActionResult resultado = categoriaExcluida == false ? NotFound(NAO_ENCONTRADA) : Ok(CATEGORIA_EXCLUIDA);
            return resultado;
        }

        [HttpPut("AtualizaCategoria/{id}")]
        public IActionResult AtualizarCategoria(Categoria categoria, int id)
        {
            var categoriaAtualizada = _categoriaService.AtualizarCategoria(categoria, id);

            IActionResult resultado = categoriaAtualizada != null ? Ok(CATEGORIA_ATUALIZADA) : NotFound(NAO_ENCONTRADA);
            return resultado;
        }
    }
}
