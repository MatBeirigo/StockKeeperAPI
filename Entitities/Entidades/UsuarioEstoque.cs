using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Entitities.Entidades
{
    [Table("UsuarioEstoque")]
    public class UsuarioEstoque
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "E-mail do Usuário")]
        public string EmailUsuario { get; set; }

        [Display(Name = "Administrador")]
        public bool Administrador { get; set; }

        [Display(Name = "Sistema Atual")]
        public bool SistemaAtual { get; set; }

        [Display(Name = "Código do Sistema")]
        //[ForeignKey("SistemaEstoque")]
        [Column(Order = 1)]
        public int IdSistema { get; set; }
        //public virtual SistemaEstoque SistemaEstoque { get; set; }
    }
}
