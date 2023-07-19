using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entitities.Entidades
{
    public class Kardex
    {
        [Key]
        [ForeignKey("IdProduto")]
        public int Id { get; set; }

        [Display(Name = "NomeProduto")]
        public string Produto { get; set; }

        [Key]
        [Display(Name = "Id da alteração")]
        public int IdAlteracao { get; set; }

        [Display(Name = "Data de alteração")]
        public DateTime DataAlteracao { get; set; }

        [Display(Name = "Tipo de alteração")]
        public string? TipoAlteracao { get; set; }

        [Display(Name = "QuantidadeEntrada")]
        public int? QuantidadeEntrada { get; set; }

        [Display(Name = "ValorUnitarioEntrada")]
        public decimal? ValorUnitarioEntrada { get; set; }

        [Display(Name = "ValorTotalEntrada")]
        public decimal? ValorTotalEntrada { get; set; }

        [Display(Name = "QuantidadeSaida")]
        public int? QuantidadeSaida { get; set; }

        [Display(Name = "ValorUnitarioSaida")]
        public decimal? ValorUnitarioSaida { get; set; }

        [Display(Name = "ValorTotalSaida")]
        public decimal? ValorTotalSaida { get; set; }

        [Display(Name = "QuantidadeSaldo")]
        public int QuantidadeSaldo { get; set; }

        [Display(Name = "ValorUnitarioSaldo")]
        public decimal ValorUnitarioSaldo { get; set; }

        [Display(Name = "ValorTotalSaldo")]
        public decimal ValorTotalSaldo { get; set; }

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
}
