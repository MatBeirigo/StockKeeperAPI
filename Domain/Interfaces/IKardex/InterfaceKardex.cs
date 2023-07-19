using Domain.Interfaces.Generica;
using Entitities.Entidades;

namespace Domain.Interfaces.IKardex
{
    public interface InterfaceKardex : InterfaceGenerica<Kardex>
    {
        public Task<List<Kardex>> ListarKardex();
        public Task<List<Kardex>> ObterKardexPorId(int Id);
        public Task IncluirKardex(Kardex kardex);
        public Task AtualizarKardex(Kardex kardex);
        public Task RemoverKardex(Kardex kardex);
    }
}
