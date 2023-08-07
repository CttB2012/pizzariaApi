using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        //public string Email { get; set; }
        //public int Celular { get; set; }
        //public string Cpf { get; set; }


        //public int EnderecoId { get; set; }

        public List<Pedido> pedidosId { get; set; }
    }
}
