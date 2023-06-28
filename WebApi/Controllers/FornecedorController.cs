using Domain.Interfaces.IFornecedor;
using Entitities.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly InterfaceFornecedor _InterfaceFornecedor;
        public FornecedorController(InterfaceFornecedor InterfaceFornecedor)
        {
            _InterfaceFornecedor = InterfaceFornecedor;
        }

        [HttpGet("/api/ListarFornecedores")]
        [Produces("application/json")]
        public async Task<object> ListarFornecedores()
        {
            return await _InterfaceFornecedor.ListarFornecedores();
        }

        [HttpPost("/api/ObterFornecedorPorId")]
        [Produces("application/json")]
        public async Task<object> ObterFornecedorPorId(int Id)
        {
            return await _InterfaceFornecedor.ObterFornecedorPorId(Id);
        }

        [HttpPost("/api/AdicionarFornecedor")]
        [Produces("application/json")]
        public async Task<IActionResult> AdicionarFornecedor([FromBody] Fornecedores fornecedor)
        {
            try
            {
                await _InterfaceFornecedor.AdicionarFornecedor(fornecedor);
                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao adicionar o fornecedor: {ex.Message}");

            }
        }

        [HttpPost("/api/EditarFornecedor")]
        [Produces("application/json")]
        public async Task<IActionResult> EditarFornecedor([FromBody] Fornecedores fornecedor)
        {
            try
            {
                await _InterfaceFornecedor.EditarFornecedor(fornecedor);
                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao editar o fornecedor: {ex.Message}");

            }
        }

        [HttpPost("/api/ExcluirFornecedor")]
        [Produces("application/json")]
        public async Task<IActionResult> ExcluirFornecedor([FromBody] Fornecedores fornecedor)
        {
            try
            {
                await _InterfaceFornecedor.ExcluirFornecedor(fornecedor);
                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao excluir o fornecedor: {ex.Message}");

            }
        }
    }
}
