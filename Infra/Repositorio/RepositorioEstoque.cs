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
                    estoqueBanco.IdAlteracao = saida.IdAlteracao + 1;

                    estoqueBanco.QuantidadeEstoque -= saida.QuantidadeEstoque;
                    estoqueBanco.ValorEstoque -= (saida.ValorUnitarioEstoque * saida.QuantidadeEstoque);
                    estoqueBanco.ValorUnitarioEstoque = estoqueBanco.ValorEstoque / estoqueBanco.QuantidadeEstoque;

                    await banco.SaveChangesAsync();
                }
            }
        }

        public async Task<int> GetQuantidadeEstoque(int produtoId)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var estoque = await banco.Set<Estoque>()
                    .FirstOrDefaultAsync(e => e.Id == produtoId);

                return estoque?.QuantidadeEstoque ?? 0;
            }
        }

        public async Task<double> GetValorUnitarioEstoque(int produtoId)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var estoque = await banco.Set<Estoque>()
                    .FirstOrDefaultAsync(e => e.Id == produtoId);

                return (double)(estoque?.ValorUnitarioEstoque ?? 0);
            }
        }
    }
}
