using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ItensDoPedido
    {
        
        public int Quantidade { get; set; }
                
        public int pedidoId { get; set; }

        public List<Produto> produtosId { get; set; }
    }
}
