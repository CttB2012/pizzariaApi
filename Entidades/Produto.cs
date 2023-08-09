using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public double Preco { get; set;}
        public string Descricao { get; set;}


        public int CategoriaId { get; set;}
    }
}
