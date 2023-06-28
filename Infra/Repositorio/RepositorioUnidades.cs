using Domain.Interfaces.IUnidades;
using Entitities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioUnidades : RepositoryGenerics<Unidades>, InterfaceUnidades
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioUnidades()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Unidades>> ListarUnidades()
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Unidade.AsNoTracking().ToListAsync();
            }
        }
    }
}
