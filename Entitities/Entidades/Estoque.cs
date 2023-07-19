using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Estoque
{
    [Key]
    [ForeignKey("IdProduto")]
    public int Id { get; set; }

    [Display(Name = "IdEmpresa")]
    public int? IdEmpresa { get; set; }

    [Display(Name = "Id da alteração")]
    public int IdAlteracao { get; set; }

    [Display(Name = "NomeProduto")]
    public string Produto { get; set; }

    [Display(Name = "QuantidadeEstoque")]
    public int QuantidadeEstoque { get; set; }

    [Display(Name = "ValorEstoque")]
    public decimal ValorEstoque { get; set; }

    [Display(Name = "ValorUnitarioEstoque")]
    public decimal ValorUnitarioEstoque { get; set; }

    //[Display(Name = "Data de alteração")]
    //public DateTime DataAlteracao { get; set; }

    //[Display(Name = "Tipo de alteração")]
    //public string? TipoAlteracao { get; set; }

    //[Display(Name = "Quantidade do produto na entrada")]
    //public int QuantidadeEntrada { get; set; }

    //[Display(Name = "Quantidade de saída do produto")]
    //public int? QuantidadeSaida { get; set; }

    //[Display(Name = "Quantidade de saldo do produto")]
    //public int? QuantidadeSaldo { get; set; }

    //[Display(Name = "Custo de entrada do produto")]
    //public decimal? CustoEntrada { get; set; }

    //[Display(Name = "Custo de saída do produto")]
    //public decimal? CustoSaida { get; set; }

    //[Display(Name = "Custo de saldo do produto")]
    //public decimal? CustoSaldo { get; set; }
}
