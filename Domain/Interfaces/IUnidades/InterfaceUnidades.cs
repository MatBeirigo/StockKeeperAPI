using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.IUnidades
{
    public interface InterfaceUnidades : InterfaceGenerica<Unidades>
    {
        public Task<List<Unidades>> ListarUnidades();
        public Task AdicionarUnidade(Unidades unidade);
        public Task EditarUnidades(Unidades unidade);
        public Task ExcluirUnidades(Unidades unidade);
    }
}
