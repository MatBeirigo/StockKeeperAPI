using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IProduto;
using Microsoft.AspNetCore.Http;
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
        public async Task<object> ListarCategorias()
        {
            return await _InterfaceCategoria.ListarCategorias();
        }
    }
}
