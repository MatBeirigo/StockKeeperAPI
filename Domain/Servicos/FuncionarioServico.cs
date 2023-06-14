using Domain.Interfaces.IFuncionario;
using Domain.Interfaces.InterfaceServicos;
using Entitities.Entidades;

namespace Domain.Servicos
{
    public class FuncionarioServico : IFuncionarioServico
    {
        private readonly InterfaceFuncionario _funcionarioInterface;
        public FuncionarioServico(InterfaceFuncionario funcionarioRepositorio)
        {
            _funcionarioInterface = funcionarioRepositorio;
        }
        public async Task AdicionarFuncionario(Funcionario funcionario)
        {
            await _funcionarioInterface.Adicionar(funcionario);
        }
        public async Task AtualizarFuncionario(Funcionario funcionario)
        {
            await _funcionarioInterface.Atualizar(funcionario);
        }
        public async Task<List<Funcionario>> ListarFuncionarios()
        {
            return await _funcionarioInterface.Listar();
        }
        public async Task<Funcionario> ObterFuncionarioPorId(int id)
        {
            return await _funcionarioInterface.ObterPorId(id);
        }
    }
}
