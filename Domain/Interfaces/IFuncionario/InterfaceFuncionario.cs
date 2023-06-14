using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.IFuncionario
{
    public interface InterfaceFuncionario : InterfaceGenerica<Funcionario>
    {
        Task AdicionarFuncionario(Funcionario funcionario);
        Task AtualizarFuncionario(Funcionario funcionario);
        Task<IList<Funcionario>> ListarFuncionarios();
        Task<IList<Funcionario>> ObterFuncionarioPorId(int Id); 
    }
}
