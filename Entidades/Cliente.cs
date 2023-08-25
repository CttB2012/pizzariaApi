using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Cliente
    {

        [Required]
        [Range(1, 9999, ErrorMessage = "A Id deve estar entre os valores 1 e 9999")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome completo deve ser informado")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome deve conter no mínimo 5 letras e, no máximo, 100.")]
        [RegularExpression(@"^([^0-9<>,.;:?/\{}!#$&*()+=%$@_-])*$", ErrorMessage = "O nome pode conter apenas letras do nosso alfabeto.")]
        public string NomeCompleto { get; set; }

        //[Required]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O email deve ser informado")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O email deve ter no mínimo 5 caracteres e, no maximo, 80")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O número de telefone deve ser informado. Apenas números são aceitos.")]
        [RegularExpression("^([0-9]{11})$", ErrorMessage = "Número de celular inválido. Informe o DDD+Número e utilize apenas números.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O número do CPF deve ser informado.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 caracteres")]
        [RegularExpression("^([0-9x]{11})$", ErrorMessage = "Cpf inválido. Verifique as informações e tente novamente.")]
        public string Cpf { get; set; }


        public int EnderecoId { get; set; }

        //public List<Pedido> pedidosId { get; set; } // perguntar sobre lista de pedidos 
    }
}
