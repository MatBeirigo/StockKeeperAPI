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

        [Display(Name = "IdEmpresa")]
        public int? IdEmpresa { get; set; }

        [Display(Name = "Id do usuário")]
        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Display(Name = "Nome de usuário")]
        [Column("Usuario")]
        public string? Usuario { get; set; }

        [Display(Name = "Permissão de administrador")]
        [Column("Admin")]
        public bool Admin { get; set; }
    }
}