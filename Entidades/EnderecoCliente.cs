using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class EnderecoCliente
    {
        [Required]
        [Range(1, 9999, ErrorMessage = "A Id deve estar entre os valores 1 e 9999")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O logradouro deve ser informado")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O logradouro deve conter no mínimo 3 letras e, no máximo, 100.")]
        [RegularExpression(@"^([^0-9<>,.;:?/\{}!#$&*()+=%$@_-])*$", ErrorMessage = "O logradouro pode conter apenas letras do nosso alfabeto")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O número deve ser informado")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O nome do bairro deve ser informado")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do bairro deve conter no mínimo 3 letras e, no máximo, 100.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O nome da cidade deve ser informado")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da cidade deve conter no mínimo 3 letras e, no máximo, 100.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "A sigla do estado deve ser informada")]
        [StringLength(2, MinimumLength = 2, ErrorMessage ="A sigla do Estado deve conter duas letras")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "A sigla do país deve ser informada")]
        [StringLength(3, MinimumLength = 2, ErrorMessage = "A sigla do País deve conter no mínimo duas letras e, no máximo, três")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "O CEP deve ser informado. Utilize apenas números.")]       
        [RegularExpression("^([0-9]){8}$", ErrorMessage = "Cep Inválido. Utilize apenas números, sem hífen e com 8 números.")]
        public string Cep { get; set; }

        public int ClienteId { get; set; }
    }
}
