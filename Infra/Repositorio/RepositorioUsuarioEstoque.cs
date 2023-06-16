using Domain.Interfaces.IUsuarioEstoque;
using Entitities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioUsuarioEstoque : RepositoryGenerics<UsuarioEstoque>, InterfaceUsuarioEstoque
    {
       private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioUsuarioEstoque()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<UsuarioEstoque>> ListarUsuarioEstoque(int idSistema)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var usuarioEstoque = await banco.UsuarioEstoque
                    .Where(t => t.IdSistema == idSistema)
                    .ToListAsync();

                return usuarioEstoque;
            }
        }

        public async Task<UsuarioEstoque> ObterUsuarioEstoque (int idUsuario, int idSistema)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                var usuarioEstoque = await banco.UsuarioEstoque
                    .Where(t => t.IdSistema == idSistema && t.Id == idUsuario)
                    .FirstOrDefaultAsync();

                return usuarioEstoque;
            }
        }

        public void RemoverUsuarioEstoque(UsuarioEstoque usuarioEstoque)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                banco.UsuarioEstoque.Remove(usuarioEstoque);
                banco.SaveChanges();
            }
        }
    }
}
