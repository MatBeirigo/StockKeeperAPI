using Domain.Interfaces.IKardex;
using Entitities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infra.Repositorio
{
    public class RepositorioKardex : RepositoryGenerics<Kardex>, InterfaceKardex
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioKardex()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task IncluirKardex(Kardex kardex) => await Adicionar(kardex);
        public async Task RemoverKardex(Kardex kardex) => await Excluir(kardex);
        public async Task AtualizarKardex(Kardex kardex) => await Atualizar(kardex);
        public async Task<List<Kardex>> ListarKardex() => await Listar();
        public async Task<List<Kardex>> ObterKardexPorId(int Id)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Kardex
                    .Where(f => f.Id == Id)
                    .ToListAsync();
            }
        }
    }
}
