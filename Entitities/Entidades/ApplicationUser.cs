using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entitities.Entidades
{
    public class ApplicationUser : IdentityUser
    {
        [Column("CODEMP")]
        public string CODEMP { get; set; }
    }
}
