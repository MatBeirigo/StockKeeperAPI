using Domain.Interfaces.IEstoque;
using Domain.Interfaces.IFornecedor;
using Domain.Interfaces.InterfaceServicos;
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
        private readonly IEstoqueServico _IEstoqueService;

        public EstoqueController(InterfaceEstoque InterfaceEstoque, IEstoqueServico IEstoqueServico)
        {
            _InterfaceEstoque = InterfaceEstoque;
            _IEstoqueService = IEstoqueServico;
        }

        [HttpGet("/api/ListarEstoque")]
        [Produces("application/json")]
        public async Task<object> ListarEstoque()
        {
            return await _InterfaceEstoque.ListarEstoque();
        }

        [HttpGet("/api/ObterEstoquePorId/{Id}")]
        [Produces("application/json")]
        public async Task<object> ObterEstoquePorId(int Id)
        {
            return await _InterfaceEstoque.ObterEstoquePorId(Id);
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
        public async Task<IActionResult> EntradaEstoque(Estoque estoque)
        {
            try
            {
                await _IEstoqueService.EntradaEstoque(estoque);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao dar entrada no estoque: {ex.Message}");

            }
        }

        [HttpPost("/api/SaidaEstoque")]
        [Produces("application/json")]
        public async Task<IActionResult> SaidaEstoque(Estoque estoque)
        {
            try
            {
                await _IEstoqueService.SaidaEstoque(estoque);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao dar saída no estoque: {ex.Message}");

            }
        }

        [HttpPost("/api/GetQuantidadeEstoque")]
        [Produces("application/json")]
        public async Task<IActionResult> GetQuantidadeEstoque([FromBody] int id)
        {
            try
            {
                var quantidade = await _InterfaceEstoque.GetQuantidadeEstoque(id);
                return Ok(quantidade);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao obter a quantidade do estoque: {ex.Message}");
            }
        }

        [HttpPost("/api/GetValorUnitarioEstoque")]
        [Produces("application/json")]
        public async Task<IActionResult> GetValorUnitarioEstoque([FromBody] int id)
        {
            try
            {
                var valorUnitario = await _InterfaceEstoque.GetValorUnitarioEstoque(id);
                return Ok(valorUnitario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao obter o valor unitário do estoque: {ex.Message}");
            }
        }

    }
}
