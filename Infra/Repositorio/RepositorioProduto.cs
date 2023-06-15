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

        public async Task EntradaEstoque(int produtoId, int quantidade)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var produto = await banco.Set<Produto>().FindAsync(produtoId);
                if (produto != null)
                {
                    produto.Quantidade += quantidade;
                    await banco.SaveChangesAsync();
                }
            }
        }

        public async Task SaidaEstoque(int produtoId, int quantidade)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var produto = await banco.Set<Produto>().FindAsync(produtoId);
                if (produto != null && produto.Quantidade >= quantidade)
                {
                    produto.Quantidade -= quantidade;
                    await banco.SaveChangesAsync();
                }
            }
        }

        public async Task<IList<Produto>> ListarProdutos()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Produto.AsNoTracking().ToListAsync();
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
                return await banco.Produto
                    .Where(f => f.NomeProduto == nome)
                    .AsNoTracking()
                    .ToListAsync();
            }
        }
    }
}
