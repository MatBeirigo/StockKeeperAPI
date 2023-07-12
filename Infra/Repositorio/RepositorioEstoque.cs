using Domain.Interfaces.IEstoque;
using Entitities.Entidades;
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
        public async Task EntradaEstoque(int Id, int quantidade)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var estoque = await banco.Set<Estoque>().FindAsync(Id);
                if (estoque != null)
                {
                    estoque.QuantidadeEntrada = quantidade;
                    estoque.QuantidadeSaldo += quantidade;
                    await banco.SaveChangesAsync();
                }
            }
        }

        public async Task SaidaEstoque(int Id, int quantidade)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var estoque = await banco.Set<Estoque>().FindAsync(Id);
                if (estoque != null)
                {
                    estoque.QuantidadeSaida = quantidade;
                    estoque.QuantidadeSaldo -= quantidade;
                    await banco.SaveChangesAsync();
                }
            }
        }

    }
}
