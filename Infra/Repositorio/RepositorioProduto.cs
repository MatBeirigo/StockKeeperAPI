using Domain.Interfaces.IProduto;
using Entitities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioProduto : RepositoryGenerics<Produto>, InterfaceProduto
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioProduto()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task EntradaEstoque(Produto produto)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                await banco.Set<Produto>().AddAsync(produto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task SaidaEstoque(Produto produto)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                banco.Set<Produto>().Update(produto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<IList<Produto>> ListarProdutos()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Produto.Include(f => f.Codigo)
                    .AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<IList<Produto>> ObterProdutoPorId(int Id)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Produto.Include(f => f.Codigo)
                    .Where(f => f.Codigo == Id)
                    .AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<IList<Produto>> ObterProdutoPorNome(string nome)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Produto.Include(f => f.NomeProduto)
                    .Where(f => f.NomeProduto == nome)
                    .AsNoTracking()
                    .ToListAsync();
            }
        }
    }
}
