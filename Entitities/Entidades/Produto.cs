using System.ComponentModel.DataAnnotations;

namespace Entitities.Entidades
{
    public class Produto
    {
        [Display(Name = "Nome do produto")]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "O campo 'Código' é obrigatório.")]
        [Display(Name = "Código do produto")]
        public int? Codigo { get; set; }

        [Display(Name = "Categoria do produto")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "O campo 'Classificação' é obrigatório.")]
        [Display(Name = "Classificação do produto")]
        public string? Classificacao { get; set; }

        [Display(Name = "Valor da compra")]
        public decimal? ValorCompra { get; set; }

        [Required(ErrorMessage = "O campo 'Valor de venda' é obrigatório.")]
        [Display(Name = "Valor da venda")]
        public decimal ValorVenda { get; set; }

        [Required(ErrorMessage = "O campo 'Quantidade' é obrigatório.")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Fornecedor")]
        public string? Fornecedor { get; set; }

        [Display(Name = "Unidade")]
        public string? Unidade { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
    }
}
