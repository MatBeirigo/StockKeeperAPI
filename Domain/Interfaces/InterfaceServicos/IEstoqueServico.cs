namespace Domain.Interfaces.InterfaceServicos
{
    public interface IEstoqueServico
    {
        Task EntradaEstoque(Estoque estoque);
        Task SaidaEstoque(Estoque estoque);
    }
}
