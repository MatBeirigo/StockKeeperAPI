using Entitities.Entidades;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IUsuarioEstoqueServico
    {
        public Task<List<UsuarioEstoque>> ListarUsuarioEstoque(int idSistema);
        public Task<UsuarioEstoque> ObterUsuarioEstoque(int idUsuario, int idSistema);
        public Task AdicionarUsuarioEstoque(UsuarioEstoque usuarioEstoque);
        public Task RemoverUsuarioEstoque(UsuarioEstoque usuarioEstoque);
        public Task AtualizarUsuarioEstoque(UsuarioEstoque usuarioEstoque);
    }
}
