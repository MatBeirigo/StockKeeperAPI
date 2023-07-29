using Domain.Interfaces.IEmpresa;
using Entitities.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly InterfaceEmpresa _InterfaceEmpresa;

        public EmpresaController(InterfaceEmpresa InterfaceEmpresa)
        {
            _InterfaceEmpresa = InterfaceEmpresa;
        }

        [HttpGet("/api/ListarEmpresa")]
        [Produces("application/json")]
        public async Task<object> ListarEmpresa()
        {
            return await _InterfaceEmpresa.ListarEmpresa();
        }

        [HttpGet("/api/ObterEmpresaPorId/{Id}")]
        [Produces("application/json")]
        public async Task<object> ObterEmpresaPorId(int Id)
        {
            return await _InterfaceEmpresa.ObterEmpresaPorId(Id);
        }

        [HttpPost("/api/AdicionarEmpresa")]
        [Produces("application/json")]
        public async Task<IActionResult> AdicionarEmpresa([FromBody] Empresas empresa)
        {
            try
            {
                await _InterfaceEmpresa.AdicionarEmpresa(empresa);
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao adicionar a empresa: {ex.Message}");

            }
        }

        [HttpPost("/api/EditarEmpresa")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarEmpresa([FromBody] Empresas empresa)
        {
            try
            {
                await _InterfaceEmpresa.AtualizarEmpresa(empresa);
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao editar a empresa: {ex.Message}");
            }
        }

        [HttpPost("/api/ExcluirEmpresa")]
        [Produces("application/json")]
        public async Task<IActionResult> ExcluirEmpresa([FromBody] Empresas empresa)
        {
            try
            {
                await _InterfaceEmpresa.ExcluirEmpresa(empresa);
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao excluir a empresa: {ex.Message}");
            }
        }   
    }
}
