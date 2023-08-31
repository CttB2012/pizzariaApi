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
        [RegularExpression(@"^([^0-9<>,.;':?/\{}!#$&*()+=%$@_-])*$", ErrorMessage = "O nome pode conter apenas letras do nosso alfabeto.")]
        public string NomeCompleto { get; set; }

        //[Required]
        [RegularExpression("^([0-9/]{10})$", ErrorMessage = "A data de nascimento deve conter apenas números e seguir o padrão xx/xx/xxxx")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "O email deve ser informado")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O email deve ter no mínimo 5 caracteres e, no maximo, 80")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O número de telefone deve ser informado.")]
        [RegularExpression("^([()0-9]{4}[0-9]{5}[-][0-9]{4}$)$", ErrorMessage = "Número de celular inválido. Informe o DDD+Número. Utilize o formato (xx)xxxxx-xxxx")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O número do CPF deve ser informado.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CPF deve conter 14 caracteres. Utilize o formato xxx.xxx.xxx-xx")]
        [RegularExpression("^([0-9]{3}[\\.][0-9]{3}[\\.][0-9]{3}[-][0-9]{2})$", ErrorMessage = "Cpf inválido. Verifique as informações e tente novamente.")]
        public string Cpf { get; set; }


        public int EnderecoId { get; set; }

        //public List<Pedido> pedidosId { get; set; } // perguntar sobre lista de pedidos 
               


    }

}

