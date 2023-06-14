using Entitities.Entidades;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IFuncionarioServico
    {
        Task AdicionarFuncionario(Funcionario funcionario);
        Task AtualizarFuncionario(Funcionario funcionario);
        Task <List<Funcionario>> ListarFuncionarios();
        Task <Funcionario> ObterFuncionarioPorId(int id);
    }
}
