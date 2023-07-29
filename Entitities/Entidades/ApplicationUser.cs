using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entitities.Entidades
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Codigo de acesso da Empresa")]
        [Column("CodigoEmpresa")]
        public string CodigoEmpresa { get; set; }

        [Display(Name = "Id do funcionario")]
        [Column("Idfuncionario")]
        public int Idfuncionario { get; set; }

        [Display(Name = "Nome de usuário")]
        [Column("Usuario")]
        public string? Usuario { get; set; }

        //public ICollection<UsuarioEmpresa> UsuarioEmpresa { get; set; }
    }
}