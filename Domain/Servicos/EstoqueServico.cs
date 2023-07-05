using Domain.Interfaces.IEstoque;
using Domain.Interfaces.InterfaceServicos;

namespace Domain.Servicos
{
    public class EstoqueServico : IEstoqueServico
    {
        private readonly InterfaceEstoque _estoqueInterface;
        public EstoqueServico(InterfaceEstoque estoqueRepositorio)
        {
            _estoqueInterface = estoqueRepositorio;
        }

        public async Task EntradaEstoque(int Id, int quantidade)
        {
            await _estoqueInterface.EntradaEstoque(Id, quantidade);
        }

        public async Task SaidaEstoque(int Id, int quantidade)
        {
            await _estoqueInterface.SaidaEstoque(Id, quantidade);
        }
    }
}
