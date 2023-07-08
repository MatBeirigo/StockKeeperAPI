using Domain.Interfaces.ICategoria;
using Entitities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioCategoria : RepositoryGenerics<Categorias>, InterfaceCategoria
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioCategoria()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Categorias>> ListarCategorias() => await Listar();
        public async Task AdicionarCategoria(Categorias categorias) => await Adicionar(categorias);
        public async Task EditarCategoria(Categorias categorias) => await Atualizar(categorias);
        public async Task ExcluirCategoria(Categorias categorias) => await Excluir(categorias);

    }
}
