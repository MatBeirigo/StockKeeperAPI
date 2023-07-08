using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.ICategoria
{
    public interface InterfaceCategoria : InterfaceGenerica<Categorias>
    {
        public Task<List<Categorias>> ListarCategorias();
        public Task AdicionarCategoria(Categorias categorias);
        public Task EditarCategoria(Categorias categorias);
        public Task ExcluirCategoria(Categorias categorias);
    }
}
