using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.IEstoque
{
    public interface InterfaceEstoque : InterfaceGenerica<Estoque>
    {
        public Task<List<Estoque>> ListarEstoque();
        public Task<Estoque> ObterEstoquePorId(int Id);
        public Task AdicionarEstoque(Estoque estoque);
        public Task AtualizarEstoque(Estoque estoque);
        public Task ExcluirEstoque(Estoque estoque);
        public Task EntradaEstoque(Estoque estoque);
        public Task SaidaEstoque(Estoque estoque);
    }
}
