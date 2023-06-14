using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.IProduto
{
    public interface InterfaceProduto : InterfaceGenerica<Produto>
    {
        Task EntradaEstoque(Produto produto);
        Task SaidaEstoque(Produto produto);
        Task<IList<Produto>> ListarProdutos();
        Task<IList<Produto>> ObterProdutoPorId(int Id);
        Task<IList<Produto>> ObterProdutoPorNome(string nome);
    }
}
