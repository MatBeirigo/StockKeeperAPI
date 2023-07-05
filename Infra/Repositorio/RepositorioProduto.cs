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

        public async Task AdicionarProduto(Produto produto) => await Adicionar(produto);

        public async Task AtualizarProduto(Produto produto) => await Atualizar(produto);

        public async Task ExcluirProduto(Produto produto) => await Excluir(produto);

        public async Task<IList<Produto>> ListarProdutos() => await Listar();

        public async Task<Produto> ObterProdutoPorId(int Id) => await ObterPorId(Id);

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
