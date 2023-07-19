using Domain.Interfaces.IEstoque;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioEstoque : RepositoryGenerics<Estoque>, InterfaceEstoque
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioEstoque()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task AdicionarEstoque(Estoque estoque) => await Adicionar(estoque);

        public async Task AtualizarEstoque(Estoque estoque) => await Atualizar(estoque);

        public async Task ExcluirEstoque(Estoque estoque) => await Excluir(estoque);

        public async Task<List<Estoque>> ListarEstoque() => await Listar();

        public async Task<Estoque> ObterEstoquePorId(int Id) => await ObterPorId(Id);
        public async Task EntradaEstoque(Estoque entrada)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var estoqueBanco = await banco.Set<Estoque>().FindAsync(entrada.Id);
                if (estoqueBanco != null)
                {
                    //estoqueBanco.TipoAlteracao = "Entrada";
                    //estoqueBanco.DataAlteracao = DateTime.Now;
                    //estoqueBanco.IdAlteracao = estoque.IdAlteracao + 1;
                    //estoqueBanco.QuantidadeEntrada = estoque.QuantidadeEntrada;
                    //estoqueBanco.QuantidadeSaldo = estoque.QuantidadeSaldo + estoque.QuantidadeEntrada;

                    estoqueBanco.IdAlteracao = entrada.IdAlteracao + 1;

                    estoqueBanco.QuantidadeEstoque += entrada.QuantidadeEstoque;
                    estoqueBanco.ValorEstoque += (entrada.ValorUnitarioEstoque * entrada.QuantidadeEstoque);
                    estoqueBanco.ValorUnitarioEstoque = estoqueBanco.ValorEstoque / estoqueBanco.QuantidadeEstoque;

                    await banco.SaveChangesAsync();
                }
            }
        }

        public async Task SaidaEstoque(Estoque saida)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var estoqueBanco = await banco.Set<Estoque>().FindAsync(saida.Id);
                if (estoqueBanco != null)
                {
                    //estoqueBanco.TipoAlteracao = "Saida";
                    //estoqueBanco.DataAlteracao = DateTime.Now;
                    //estoqueBanco.IdAlteracao = estoque.IdAlteracao + 1;
                    //estoqueBanco.QuantidadeSaida = estoque.QuantidadeSaida;

                    //if(estoque.QuantidadeSaldo - estoque.QuantidadeSaida > 0)
                    //{
                    //    estoqueBanco.QuantidadeSaldo = estoque.QuantidadeSaldo - estoque.QuantidadeSaida;
                    //}
                    //else
                    //{
                    //    estoqueBanco.QuantidadeSaldo = 0;
                    //}

                    estoqueBanco.IdAlteracao = saida.IdAlteracao + 1;

                    estoqueBanco.QuantidadeEstoque -= saida.QuantidadeEstoque;
                    estoqueBanco.ValorEstoque -= (saida.ValorUnitarioEstoque * saida.QuantidadeEstoque);
                    estoqueBanco.ValorUnitarioEstoque = estoqueBanco.ValorEstoque / estoqueBanco.QuantidadeEstoque;

                    await banco.SaveChangesAsync();
                }
            }
        }
    }
}
