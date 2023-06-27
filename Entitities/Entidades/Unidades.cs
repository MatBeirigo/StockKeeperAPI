using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Entitities.Entidades
{
    public class Unidades
    {
        [Key]
        [Display(Name = "Unidade")]
        public string Unidade { get; set; }
    }
}
