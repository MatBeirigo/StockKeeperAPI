using Domain.Interfaces.IEstoque;
using Domain.Interfaces.IFornecedor;
using Entitities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly InterfaceEstoque _InterfaceEstoque;
        public EstoqueController(InterfaceEstoque InterfaceEstoque)
        {
            _InterfaceEstoque = InterfaceEstoque;
        }

        [HttpGet("/api/ListarEstoque")]
        [Produces("application/json")]
        public async Task<object> ListarEstoque()
        {
            return await _InterfaceEstoque.ListarEstoque();
        }

        [HttpPost("/api/AdicionarEstoque")]
        [Produces("application/json")]
        public async Task<IActionResult> AdicionarEstoque([FromBody] Estoque estoque)
        {
            try
            {
                await _InterfaceEstoque.AdicionarEstoque(estoque);
                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao adicionar o estoque: {ex.Message}");

            }
        }

        [HttpPost("/api/EditarEstoque")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarEstoque([FromBody] Estoque estoque)
        {
            try
            {
                await _InterfaceEstoque.AtualizarEstoque(estoque);
                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao editar o estoque: {ex.Message}");

            }
        }

        [HttpPost("/api/ExcluirEstoque")]
        [Produces("application/json")]
        public async Task<IActionResult> ExcluirEstoque([FromBody] Estoque estoque)
        {
            try
            {
                await _InterfaceEstoque.ExcluirEstoque(estoque);
                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao excluir o estoque: {ex.Message}");

            }
        }

        [HttpPost("/api/EntradaEstoque")]
        [Produces("application/json")]
        public async Task<IActionResult> EntradaEstoque(int Id, int quantidade)
        {
            try
            {
                await _InterfaceEstoque.EntradaEstoque(Id, quantidade);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao dar entrada no estoque: {ex.Message}");

            }
        }

        [HttpPost("/api/SaidaEstoque")]
        [Produces("application/json")]
        public async Task<IActionResult> SaidaEstoque(int Id, int quantidade)
        {
            try
            {
                await _InterfaceEstoque.SaidaEstoque(Id, quantidade);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao dar saída no estoque: {ex.Message}");

            }
        }
    }
}
