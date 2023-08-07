using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {
        public int Id { get; set; }


        public  OrigemDoPedidoEnum OrigemDoPedido{ get; set; }

        public int ItensDoPedidoId { get; set; }

        public int ClienteId { get; set; }
    }
}
