namespace Domain.Interfaces.InterfaceServicos
{
    public interface IEstoqueServico
    {
        Task EntradaEstoque(int Id, int quantidade);
        Task SaidaEstoque(int Id, int quantidade);
    }
}
