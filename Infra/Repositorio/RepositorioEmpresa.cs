using Domain.Interfaces.IEmpresa;
using Entitities.Entidades;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio
{
    public class RepositorioEmpresa : RepositoryGenerics<Empresas>, InterfaceEmpresa
    {
        public async Task AdicionarEmpresa(Empresas empresa) => await Adicionar(empresa);
        public async Task AtualizarEmpresa(Empresas empresa) => await Atualizar(empresa);
        public async Task ExcluirEmpresa(Empresas empresa) => await Excluir(empresa);
        public async Task<List<Empresas>> ListarEmpresa() => await Listar();
        public async Task<Empresas> ObterEmpresaPorId(int Id) => await ObterPorId(Id);
    }
}
