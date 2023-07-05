using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.IProduto
{
    public interface InterfaceProduto : InterfaceGenerica<Produto>
    {
        public Task<IList<Produto>> ListarProdutos();
        public Task<Produto> ObterProdutoPorId(int Id);
        public Task<IList<Produto>> ObterProdutoPorNome(string nome);
        public Task AdicionarProduto(Produto produto);
        public Task AtualizarProduto(Produto produto);
        public Task ExcluirProduto(Produto produto);
    }
}
