using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.IEstoque
{
    public interface InterfaceEstoque : InterfaceGenerica<Estoque>
    {
        public Task<List<Estoque>> ListarEstoque();
        public Task AdicionarEstoque(Estoque estoque);
        public Task AtualizarEstoque(Estoque estoque);
        public Task ExcluirEstoque(Estoque estoque);
        public Task EntradaEstoque(int Id, int quantidade);
        public Task SaidaEstoque(int Id, int quantidade);
    }
}
