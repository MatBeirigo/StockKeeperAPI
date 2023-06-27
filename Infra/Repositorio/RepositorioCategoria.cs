using Domain.Interfaces.ICategoria;
using Entitities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioCategoria : RepositoryGenerics<Categorias>, InterfaceCategoria
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioCategoria()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Categorias>> ListarCategorias()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Categoria.AsNoTracking().ToListAsync();
            }
        }
    }
}
