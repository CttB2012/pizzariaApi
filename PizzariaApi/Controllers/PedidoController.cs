using Entidades;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

namespace PizzariaApi.Controllers
{
    [Route("PizzariaApi/[Controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        public const string NAO_ENCONTRADO = "Pedido nao encontrado na base de dados";
        public const string PEDIDO_EXCLUIDO = "Pedido excluido com sucesso";
        public const string PEDIDO_ATUALIZADO = "Pedido atualizado com sucesso";

        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost("InsereNovoPedido")]
        public IActionResult InserirNovoPedido(Pedido pedido)
        {
            var novoPedido = _pedidoService.InserirNovoPedido(pedido);
            return Ok(novoPedido);
        }

        [HttpGet("ListaTodosOsPedidos")]
        public IActionResult ListaTodosOsPedidos()
        {
            var listaDosPedidos = _pedidoService.ListaTodosOsPedidos();
            return Ok(listaDosPedidos);
        }

        [HttpGet("ListaPedidoPelaId")]
        public IActionResult ListaPedidoPelaId(int id)
        {
            var pedidoDetalhado = _pedidoService.ListaPedidoPelaId(id);

            IActionResult resultado = pedidoDetalhado == null ? NotFound(NAO_ENCONTRADO) : Ok(pedidoDetalhado);

            return resultado;
        }

        [HttpDelete("ExcluiPedido")]
        public IActionResult ExcluirPedido(int id)
        {
            var pedidoExcluido = _pedidoService.ExcluirPedido(id);
            IActionResult resultado = pedidoExcluido == false ? NotFound(NAO_ENCONTRADO) : Ok(pedidoExcluido);
            return resultado;
        }
    }

}


