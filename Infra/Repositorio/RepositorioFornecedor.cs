using Domain.Interfaces.IFornecedor;
using Entitities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioFornecedor : RepositoryGenerics<Fornecedores>, InterfaceFornecedor
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioFornecedor()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task AdicionarFornecedor(Fornecedores fornecedor) => await Adicionar(fornecedor);

        public async Task EditarFornecedor(Fornecedores fornecedor) => await Atualizar(fornecedor);

        public async Task ExcluirFornecedor(Fornecedores fornecedor) => await Excluir(fornecedor);
        public async Task<Fornecedores> ObterFornecedorPorId(int Id) => await ObterPorId(Id);
        public async Task<List<Fornecedores>> ListarFornecedores() => await Listar();
    }
}
