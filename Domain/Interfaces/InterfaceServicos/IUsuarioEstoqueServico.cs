using Entitities.Entidades;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IUsuarioEstoqueServico
    {
        Task AdicionarUsuarioEstoque(UsuarioEstoque usuarioEstoque);
    }
}
