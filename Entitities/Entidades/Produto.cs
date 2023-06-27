using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entitities.Entidades
{
    public class Produto
    {
        [Display(Name = "Nome do produto")]
        public string NomeProduto { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código do produto")]
        public int? Codigo { get; set; }

        [Display(Name = "Categoria do produto")]
        public string? Categoria { get; set; }

        [Display(Name = "Classificação do produto")]
        public string? Classificacao { get; set; }

        [Display(Name = "Valor da compra")]
        public decimal? ValorCompra { get; set; }

        [Display(Name = "Valor da venda")]
        public decimal? ValorVenda { get; set; }

        [Display(Name = "Quantidade")]
        public int? Quantidade { get; set; }

        [Display(Name = "Cor")]
        public string? Cor { get; set; }

        [Display(Name = "Sabor")]
        public string? Sabor { get; set; }

        [Display(Name = "Fornecedor")]
        public string? Fornecedor { get; set; }

        [Display(Name = "Unidade")]
        public string? Unidade { get; set; }

        [Display(Name = "Peso")]
        public decimal? Peso { get; set; }

        [Display(Name = "Dimensão da Embalagem")]
        public decimal? DimensaoEmbalagem { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Display(Name = "Informações Fiscais")]
        public string? InformacoesFiscais { get; set; }

        [Display(Name = "Código de Barras")]
        public int? CodigoBarras { get; set; }
    }
}
