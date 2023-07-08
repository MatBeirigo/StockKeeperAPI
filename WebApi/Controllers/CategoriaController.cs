using Domain.Interfaces.ICategoria;
using Entitities.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly InterfaceCategoria _InterfaceCategoria;
        public CategoriaController(InterfaceCategoria InterfaceCategoria)
        {
            _InterfaceCategoria = InterfaceCategoria;
        }

        [HttpGet("/api/ListarCategorias")]
        [Produces("application/json")]
        public async Task<List<string>> ListarCategorias()
        {
            var categorias = await _InterfaceCategoria.ListarCategorias();
            return categorias.Select(categoria => categoria.Nome).ToList();
        }

        [HttpPost("/api/AdicionarCategoria")]
        [Produces("application/json")]
        public async Task AdicionarCategoria([FromBody] Categorias categorias)
        {
            await _InterfaceCategoria.AdicionarCategoria(categorias);
        }
    }
}
