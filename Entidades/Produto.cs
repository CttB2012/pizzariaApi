using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Produto
    {
        [Required(ErrorMessage ="A id do produto é obrigatória")]
        [Range(1, 9999, ErrorMessage = "A id do produto deve estar entre 1 e 9999")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve conter no mínimo 3 letras e, no máximo, 50.")]
        [RegularExpression(@"^([^0-9<>,.;:?/\{}!#$&*()+=%$@_-])*$", ErrorMessage = "O nome pode conter apenas letras do nosso alfabeto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço do produto é obrigatório")]
        public double Preco { get; set;}

        [StringLength(250, MinimumLength = 5, ErrorMessage = "A descrição deve conter no mínimo 5 caracteres e, no máximo, 250.")]
        public string Descricao { get; set;}

        public int CategoriaId { get; set;}
    }
}
