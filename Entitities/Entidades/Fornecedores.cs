using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Entitities.Enums;

namespace Entitities.Entidades
{
    public class Fornecedores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID do Fornecedor")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome Fantasia é obrigatório.")]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "CNPJ")]
        public string? Cnpj { get; set; }

        [Display(Name = "CPF")]
        public string? Cpf { get; set; }

        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }

        [Display(Name = "CEP")]
        public string? Cep { get; set; }

        [Display(Name = "Cidade")]
        public string? Cidade { get; set; }

        [Display(Name = "Estado")]
        public string? Estado { get; set; }

        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }

        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [Display(Name = "Site")]
        public string? Site { get; set; }

        [Display(Name = "Tipo de Fornecedor")]
        public string? TipoFornecedor { get; set; }
    }
}
