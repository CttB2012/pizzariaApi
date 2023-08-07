using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPedidoService
    {
        string InserirNovoPedido(Pedido pedido);
        List<Pedido> ListaTodosOsPedidos();
        public Pedido ListaPedidoPelaId(int id);
        bool ExcluirPedido(int id);
    }
}
