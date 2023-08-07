using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Interfaces
{
    public interface IPedidoRepositorio
    {
        Pedido InserirNovoPedido(Pedido pedido);
        public List<Pedido> ListaTodosOsPedidos();
        public Pedido ListaPedidoPelaId(int id);
        bool ExcluirPedido(int id);
        Pedido AtualizarPedido(Pedido pedido, int id);
    }
}
