using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioEstoque;
using Entitities.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioEstoqueController : ControllerBase
    {
        private readonly InterfaceUsuarioEstoque _InterfaceUsuarioEstoque;
        private readonly IUsuarioEstoqueServico _IUsuarioEstoqueService;

        public UsuarioEstoqueController(InterfaceUsuarioEstoque InterfaceUsuarioEstoque, IUsuarioEstoqueServico IUsuarioEstoqueServico)
        {
            _InterfaceUsuarioEstoque = InterfaceUsuarioEstoque;
            _IUsuarioEstoqueService = IUsuarioEstoqueServico;
        }

        [HttpPost("/api/ListarUsuarioEstoque")]
        [Produces("application/json")]
        public async Task<object> ListarUsuarioEstoque(int idSistema)
        {
            return await _IUsuarioEstoqueService.ListarUsuarioEstoque(idSistema);
        }

        [HttpPost("/api/AdicionarUsuarioEstoque")]
        [Produces("application/json")]
        public async Task<object> AdicionarUsuarioEstoque(UsuarioEstoque usuarioEstoque)
        {
            await _IUsuarioEstoqueService.AdicionarUsuarioEstoque(usuarioEstoque);
            return Task.FromResult(usuarioEstoque);
        }

        [HttpPost("/api/AtualizarUsuarioEstoque")]
        [Produces("application/json")]
        public async Task<object> AtualizarUsuarioEstoque(UsuarioEstoque usuarioEstoque)
        {
            try
            {
                await _IUsuarioEstoqueService.AtualizarUsuarioEstoque(usuarioEstoque);
                return Ok("Usuário atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("/api/ExcluirUsuarioEstoque")]
        [Produces("application/json")]
        public async Task<object> ExcluirUsuarioEstoque(UsuarioEstoque usuarioEstoque)
        {
            try
            {
                await _IUsuarioEstoqueService.RemoverUsuarioEstoque(usuarioEstoque);
                return Ok("Usuário excluído com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("/api/ObterUsuarioEstoque")]
        [Produces("application/json")]
        public async Task<object> ObterUsuarioEstoque(int idUsuario, int idSistema)
        {
            return await _IUsuarioEstoqueService.ObterUsuarioEstoque(idUsuario, idSistema);
        }
    }
}
