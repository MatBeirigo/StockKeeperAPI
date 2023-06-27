using System.ComponentModel.DataAnnotations;

namespace Entitities.Entidades
{
    public class Categorias
    {
        [Key]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}
