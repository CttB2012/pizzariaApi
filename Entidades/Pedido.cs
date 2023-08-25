using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {
        [Required]
        [Range(1, 9999, ErrorMessage = "A Id deve estar entre os valores 1 e 9999")]
        public int Id { get; set; }

        [Required(ErrorMessage = "A origem do pedido é obrigatóra. ifood = 1, whatsApp = 2, telefone = 3, app = 4")]
        public  OrigemDoPedidoEnum OrigemDoPedido{ get; set; }

        public List<ItensDoPedido> ItensDoPedido { get; set; }

        public int ClienteId { get; set; }
    }
}
