using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Entitities.Entidades
{
    public class Funcionario
    {
        [Key]
        [Display(Name = "IdFuncionario")]
        public int Id { get; set; }

        [ForeignKey("IdEmpresa")]
        [Display(Name = "IdEmpresa")]
        public int IdEmpresa { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "Tipo")]
        public int Tipo { get; set; }
        //public Funcionario() { }
    }
}
