using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.IProduto
{
    public interface InterfaceProduto : InterfaceGenerica<Produto>
    {
        Task EntradaEstoque(int produtoId, int quantidade);
        Task SaidaEstoque(int produtoId, int quantidade);
        Task<IList<Produto>> ObterProdutoPorId(int Id);
        Task<IList<Produto>> ObterProdutoPorNome(string nome);
    }
}
