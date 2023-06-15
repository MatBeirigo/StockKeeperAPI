using Entitities.Entidades;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IProdutoServico
    {
        Task AdicionarProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task ExcluirProduto(Produto produto);
        Task<Produto> ObterProdutoPorId(int Id);
        Task<IList<Produto>> ListarProdutos();
        Task<IList<Produto>> ObterProdutoPorNome(string nome);
        Task EntradaEstoque(int produtoId, int quantidade);
        Task SaidaEstoque(int produtoId, int quantidade);
    }
}
