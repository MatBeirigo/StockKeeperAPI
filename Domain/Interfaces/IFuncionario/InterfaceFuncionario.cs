using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.IFuncionario
{
    public interface InterfaceFuncionario : InterfaceGenerica<Funcionario>
    {
        Task<IList<Funcionario>> ListarFuncionarios();
        Task<IList<Funcionario>> ObterFuncionarioPorId(int Id);
    }
}
