using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.ICategoria
{
    public interface InterfaceCategoria : InterfaceGenerica<Categorias>
    {
        public Task<IList<Categorias>> ListarCategorias();
    }
}
