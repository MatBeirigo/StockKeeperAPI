using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.IFornecedor
{
    public interface InterfaceFornecedor : InterfaceGenerica<Fornecedores>
    {
        public Task AdicionarFornecedor(Fornecedores fornecedor);
        public Task EditarFornecedor(Fornecedores fornecedor);
        public Task ExcluirFornecedor(Fornecedores fornecedor);
        public Task<Fornecedores> ObterFornecedorPorId(int Id);
        public Task<List<Fornecedores>> ListarFornecedores();
    }
}
