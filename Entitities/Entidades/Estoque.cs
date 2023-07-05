using Entitities.Entidades;
using Entitities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

public class Estoque
{
    [Key]
    [ForeignKey("CodigoProduto")]
    public int Codigo { get; set; }

    [Display(Name = "NomeProduto")]
    public string Produto { get; set; }

    [Display(Name = "Data de alteração")]
    public DateTime DataAlteracao { get; set; }

    [Display(Name = "Tipo de alteração")]
    public EnumTipoAlteracao? TipoAlteracao { get; set; }

    [Display(Name = "Quantidade do produto na entrada")]
    public int? QuantidadeEntrada { get; set; }

    [Display(Name = "Quantidade de saída do produto")]
    public int? QuantidadeSaida { get; set; }

    [Display(Name = "Quantidade de saldo do produto")]
    public int? QuantidadeSaldo { get; set; }

    [Display(Name = "Custo de entrada do produto")]
    public decimal? CustoEntrada { get; set; }

    [Display(Name = "Custo de saída do produto")]
    public decimal? CustoSaida { get; set; }

    [Display(Name = "Custo de saldo do produto")]
    public decimal? CustoSaldo { get; set; }
}
