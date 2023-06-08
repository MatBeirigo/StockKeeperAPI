using System.Threading.Tasks;

namespace Domain.Interfaces.Generica
{
    public interface InterfaceGenerica<T> where T : class
    {
        Task Adicionar(T Objeto);
        Task Atualizar(T Objeto);
        Task Excluir(T Objeto);
        Task<T> ObterPorId(int Id);
        Task<List<T>> Listar();
    }
}
