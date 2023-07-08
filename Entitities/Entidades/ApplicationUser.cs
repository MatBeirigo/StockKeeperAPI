using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entitities.Entidades
{
    public class ApplicationUser : IdentityUser
    {
        [Column("Codigo da empresa")]
        public string CodigoEmpresa { get; set; }

        public ICollection<UsuarioEmpresa> UsuarioEmpresa { get; set; }
    }
}