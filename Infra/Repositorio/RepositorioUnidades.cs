using Domain.Interfaces.IUnidades;
using Entitities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioUnidades : RepositoryGenerics<Unidades>, InterfaceUnidades
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioUnidades()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Unidades>> ListarUnidades() => await Listar();
        public async Task AdicionarUnidade(Unidades unidade) => await Adicionar(unidade);
        public async Task EditarUnidades(Unidades unidade) => await Atualizar(unidade);
        public async Task ExcluirUnidades(Unidades unidade) => await Excluir(unidade);
    }
}
