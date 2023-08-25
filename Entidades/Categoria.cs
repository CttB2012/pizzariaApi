using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoria
    {
        [Required]
        [Range(1, 9999, ErrorMessage = "A Id deve estar entre os valores 1 e 9999")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da categoria deve conter no mínimo 3 letras e, no máximo, 100.")]
        [RegularExpression(@"^([^0-9<>,.;:?/\{}!#$&*()+=%$@_-])*$", ErrorMessage = "O nome pode conter apenas letras do nosso alfabeto")]
        public string Nome { get; set; }
    }
}
