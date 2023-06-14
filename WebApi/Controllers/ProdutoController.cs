using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IProduto;
using Entitities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly InterfaceProduto _InterfaceProduto;
        private readonly IProdutoServico _IProdutoService;
        public ProdutoController(InterfaceProduto InterfaceProduto, IProdutoServico IProdutoServico)
        {
            _InterfaceProduto = InterfaceProduto;
            _IProdutoService = IProdutoServico;
        }

        [HttpPost("/api/ListarProdutos")]
        [Produces("application/json")]

        public async Task<object> ListarProdutos()
        {
            return await _InterfaceProduto.ListarProdutos();
        }

        [HttpPost("/api/AdicionarProduto")]
        [Produces("application/json")]
        public async Task<object> AdicionarProduto(Produto produto)
        {
            //try
            //{
            //    await _IProdutoService.AdicionarProduto(produto);
            //    return Ok("Produto cadastrado com sucesso");
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            //}

            await _IProdutoService.AdicionarProduto(produto);
            return Task.FromResult(produto);
        }

        [HttpPost("/api/AtualizarProduto")]
        [Produces("application/json")]
        public async Task<object> AtualizarProduto(Produto produto)
        {
            try
            {
                await _IProdutoService.AtualizarProduto(produto);
                return Ok("Produto atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("/api/ExcluirProduto")]
        [Produces("application/json")]
        public async Task<object> ExcluirProduto(Produto produto)
        {
            try
            {
                await _IProdutoService.ExcluirProduto(produto);
                return Ok("Produto excluído com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("/api/ObterProdutoPorId")]
        [Produces("application/json")]
        public async Task<object> ObterProdutoPorId(int Id)
        {
            try
            {
                return await _IProdutoService.ObterProdutoPorId(Id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("/api/ObterProdutoPorNome")]
        [Produces("application/json")]
        public async Task<object> ObterProdutoPorNome(string nome)
        {
            try
            {
                return await _IProdutoService.ObterProdutoPorNome(nome);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("/api/EntradaEstoque")]
        [Produces("application/json")]
        public async Task<object> EntradaEstoque(Produto produto)
        {
            try
            {
                await _IProdutoService.EntradaEstoque(produto);
                return Ok("Entrada de estoque realizada com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("/api/SaidaEstoque")]
        [Produces("application/json")]
        public async Task<object> SaidaEstoque(Produto produto)
        {
            try
            {
                await _IProdutoService.SaidaEstoque(produto);
                return Ok("Saída de estoque realizada com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
