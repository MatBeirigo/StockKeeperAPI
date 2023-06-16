using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioEstoque;
using Entitities.Entidades;

namespace Domain.Servicos
{
    public class UsuarioEstoqueServico : IUsuarioEstoqueServico
    {
        private readonly InterfaceUsuarioEstoque _usuarioEstoqueInterface;

        public UsuarioEstoqueServico(InterfaceUsuarioEstoque usuarioEstoqueRepositorio)
        {
            _usuarioEstoqueInterface = usuarioEstoqueRepositorio;
        }

        public async Task AdicionarUsuarioEstoque(UsuarioEstoque usuarioEstoque)
        {
            await _usuarioEstoqueInterface.Adicionar(usuarioEstoque);
        }

        public async Task RemoverUsuarioEstoque(UsuarioEstoque usuarioEstoque)
        {
            var existingUsuarioEstoque = await _usuarioEstoqueInterface.ObterUsuarioEstoque(usuarioEstoque.Id, usuarioEstoque.IdSistema);

            if (existingUsuarioEstoque == null)
            {
                throw new InvalidOperationException("O usuário de estoque não existe e não pode ser removido.");
            }

            await _usuarioEstoqueInterface.Excluir(usuarioEstoque);
        }

        public async Task AtualizarUsuarioEstoque(UsuarioEstoque usuarioEstoque)
        {
            var existingUsuarioEstoque = await _usuarioEstoqueInterface.ObterUsuarioEstoque(usuarioEstoque.Id, usuarioEstoque.IdSistema);

            if (existingUsuarioEstoque == null)
            {
                throw new InvalidOperationException("O usuário de estoque não existe e não pode ser atualizado.");
            }

            await _usuarioEstoqueInterface.Atualizar(usuarioEstoque);
        }


        public async Task<List<UsuarioEstoque>> ListarUsuarioEstoque(int idSistema)
        {
            return await _usuarioEstoqueInterface.ListarUsuarioEstoque(idSistema);
        }

        public async Task<UsuarioEstoque> ObterUsuarioEstoque(int idUsuario, int idSistema)
        {
            return await _usuarioEstoqueInterface.ObterUsuarioEstoque(idUsuario, idSistema);
        }
    }
}
