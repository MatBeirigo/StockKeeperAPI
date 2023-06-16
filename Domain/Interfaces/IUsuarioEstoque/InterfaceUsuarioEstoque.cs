using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.IUsuarioEstoque
{
    public interface InterfaceUsuarioEstoque : InterfaceGenerica<UsuarioEstoque>
    {
        public Task<List<UsuarioEstoque>> ListarUsuarioEstoque(int idSistema);
        public Task<UsuarioEstoque> ObterUsuarioEstoque(int idUsuario, int idSistema);
        public void RemoverUsuarioEstoque(UsuarioEstoque usuarioEstoque);
    }
}
