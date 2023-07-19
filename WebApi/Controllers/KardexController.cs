using Domain.Interfaces.IKardex;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IProduto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KardexController : ControllerBase
    {
        private readonly InterfaceKardex _InterfaceKardex;

        public KardexController(InterfaceKardex InterfaceKardex)
        {
            _InterfaceKardex = InterfaceKardex;
        }

        [HttpGet("/api/ListarKardex")]
        [Produces("application/json")]
        public async Task<object> ListarKardex()
        {
            return await _InterfaceKardex.ListarKardex();
        }

        [HttpGet("/api/ObterKardexPorId/{Id}")]
        [Produces("application/json")]
        public async Task<object> ObterKardexPorId(int Id)
        {
            return await _InterfaceKardex.ObterKardexPorId(Id);
        }

    }
}
