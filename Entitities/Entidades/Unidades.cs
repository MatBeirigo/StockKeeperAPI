using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Entitities.Entidades
{
    public class Unidades
    {
        [Key]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}
