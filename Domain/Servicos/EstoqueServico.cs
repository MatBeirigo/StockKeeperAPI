using Domain.Interfaces.IEstoque;
using Domain.Interfaces.IKardex;
using Domain.Interfaces.InterfaceServicos;
using Entitities.Entidades;

namespace Domain.Servicos
{
    public class EstoqueServico : IEstoqueServico
    {
        private readonly InterfaceEstoque _estoqueInterface;
        private readonly InterfaceKardex _kardexInterface;

        public EstoqueServico(InterfaceEstoque estoqueRepositorio, InterfaceKardex kardexRepositorio)
        {
            _estoqueInterface = estoqueRepositorio;
            _kardexInterface = kardexRepositorio;
        }

        public async Task EntradaEstoque(Estoque entrada)
        {
            try
            {
                Estoque dadosExistentesEstoque = await _estoqueInterface.ObterPorId(entrada.Id);

                Kardex kardex = new Kardex
                {
                    //Codigo = estoque.Codigo,
                    //Produto = estoque.Produto,
                    //IdAlteracao = int.Parse(estoque.IdAlteracao.ToString()) + 1,
                    //DataAlteracao = DateTime.Now,
                    //TipoAlteracao = "Entrada",
                    //QuantidadeEntrada = estoque.QuantidadeEntrada,
                    //QuantidadeSaida = 0,
                    //QuantidadeSaldo = estoque.QuantidadeSaldo + estoque.QuantidadeEntrada,
                    //CustoEntrada = estoque.CustoEntrada,
                    //CustoSaida = 0,
                    //CustoSaldo = estoque.CustoSaldo + estoque.CustoEntrada

                    Id = entrada.Id,
                    Produto = entrada.Produto,
                    IdAlteracao = int.Parse(entrada.IdAlteracao.ToString()) + 1,
                    DataAlteracao = DateTime.Now,
                    TipoAlteracao = "Entrada",
                    QuantidadeEntrada = entrada.QuantidadeEstoque,
                    ValorUnitarioEntrada = entrada.ValorUnitarioEstoque,
                    ValorTotalEntrada = (entrada.QuantidadeEstoque * entrada.ValorUnitarioEstoque),
                    QuantidadeSaida = 0,
                    ValorUnitarioSaida = 0,
                    ValorTotalSaida = 0,
                    QuantidadeSaldo = dadosExistentesEstoque.QuantidadeEstoque + entrada.QuantidadeEstoque,
                    ValorUnitarioSaldo = ((dadosExistentesEstoque.ValorEstoque + (entrada.QuantidadeEstoque * entrada.ValorUnitarioEstoque)) / (dadosExistentesEstoque.QuantidadeEstoque + entrada.QuantidadeEstoque)),
                    ValorTotalSaldo = dadosExistentesEstoque.ValorEstoque + (entrada.QuantidadeEstoque * entrada.ValorUnitarioEstoque)
                };

                await _estoqueInterface.EntradaEstoque(entrada);
                await _kardexInterface.IncluirKardex(kardex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao tentar dar entrada no estoque: {ex.Message}");
            }
        }

        public async Task SaidaEstoque(Estoque saida)
        {
            try
            {
                Estoque dadosExistentesEstoque = await _estoqueInterface.ObterPorId(saida.Id);

                Kardex kardex = new Kardex
                {
                    //Codigo = estoque.Codigo,
                    //Produto = estoque.Produto,
                    //IdAlteracao = int.Parse(estoque.IdAlteracao.ToString()) + 1,
                    //DataAlteracao = DateTime.Now,
                    //TipoAlteracao = "Saida",
                    //QuantidadeEntrada = 0,
                    //QuantidadeSaida = estoque.QuantidadeSaida,
                    //QuantidadeSaldo = estoque.QuantidadeSaldo - estoque.QuantidadeSaida,
                    //CustoEntrada = 0,
                    //CustoSaida = estoque.CustoSaida,
                    //CustoSaldo = estoque.CustoSaldo + estoque.CustoSaida

                    Id = saida.Id,
                    Produto = saida.Produto,
                    IdAlteracao = int.Parse(saida.IdAlteracao.ToString()) + 1,
                    DataAlteracao = DateTime.Now,
                    TipoAlteracao = "Saída",
                    QuantidadeEntrada = 0,
                    ValorUnitarioEntrada = 0,
                    ValorTotalEntrada = 0,
                    QuantidadeSaida = saida.QuantidadeEstoque,
                    ValorUnitarioSaida = saida.ValorUnitarioEstoque,
                    ValorTotalSaida = (saida.QuantidadeEstoque * saida.ValorUnitarioEstoque),
                    QuantidadeSaldo = dadosExistentesEstoque.QuantidadeEstoque - saida.QuantidadeEstoque,
                    ValorUnitarioSaldo = ((dadosExistentesEstoque.ValorEstoque - (saida.QuantidadeEstoque * saida.ValorUnitarioEstoque)) / (dadosExistentesEstoque.QuantidadeEstoque - saida.QuantidadeEstoque)),
                    ValorTotalSaldo = dadosExistentesEstoque.ValorEstoque - (saida.QuantidadeEstoque * saida.ValorUnitarioEstoque)
                };

                await _estoqueInterface.SaidaEstoque(saida); ;
                await _kardexInterface.IncluirKardex(kardex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao tentar dar entrada no estoque: {ex.Message}");
            }
        }
    }
}
