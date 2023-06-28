using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.IUnidades
{
    public interface InterfaceUnidades : InterfaceGenerica<Unidades>
    {
        public Task<IList<Unidades>> ListarUnidades();

    }
}
