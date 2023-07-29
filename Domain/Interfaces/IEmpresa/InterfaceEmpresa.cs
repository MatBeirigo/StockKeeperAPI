using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.IEmpresa
{
    public interface InterfaceEmpresa : InterfaceGenerica<Empresas>
    {
        public Task<List<Empresas>> ListarEmpresa();
        public Task<Empresas> ObterEmpresaPorId(int Id);
        public Task AdicionarEmpresa(Empresas empresa);
        public Task AtualizarEmpresa(Empresas empresa);
        public Task ExcluirEmpresa(Empresas empresa);
    }
}
