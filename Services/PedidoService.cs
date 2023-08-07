using Entidades;
using Repositorios.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PedidoService : IPedidoService
    {
        public const string PEDIDO_CADASTRADO = "Pedido cadastrado no sistema";
        public const string PEDIDO_NULO = "Pedido nulo. Informe um pedido para continuar";
        public const string ORIGEM_INVALIDA = "Origem do pedido invalida";


        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoService(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        public string InserirNovoPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                return PEDIDO_NULO;
            }

            if (ValidarOrigemPedido(pedido.OrigemDoPedidoEnum) == false)
            {
                return ORIGEM_INVALIDA;
            }
            _pedidoRepositorio.InserirNovoPedido(pedido);
            return PEDIDO_CADASTRADO;
        }

        public bool ValidarOrigemPedido(OrigemDoPedidoEnum origemDoPedido)
        {
            if (origemDoPedido == OrigemDoPedidoEnum.ifood || origemDoPedido == OrigemDoPedidoEnum.whatsApp ||
                origemDoPedido == OrigemDoPedidoEnum.whatsApp || origemDoPedido == OrigemDoPedidoEnum.app)
            {
                return true;
            }
            return false;
        }

        public List<Pedido> ListaTodosOsPedidos()
        {
            var listaDePedidos = _pedidoRepositorio.ListaTodosOsPedidos();
            return listaDePedidos;
        }

        public Pedido ListaPedidoPelaId(int id)
        {
            var pedidoDetalhado = _pedidoRepositorio.ListaPedidoPelaId(id);
            return pedidoDetalhado;
        }

        public bool ExcluirPedido(int id)
        {
            var pedidoExcluido = _pedidoRepositorio.ExcluirPedido(id);
            return pedidoExcluido;
        }
    }
}
