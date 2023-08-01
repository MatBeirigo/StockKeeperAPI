using Domain.Interfaces.IEmpresa;
using Entitities.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly InterfaceEmpresa _InterfaceEmpresa;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmpresaController(InterfaceEmpresa InterfaceEmpresa, UserManager<ApplicationUser> userManager)
        {
            _InterfaceEmpresa = InterfaceEmpresa;
            _userManager = userManager;
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

                var user = new ApplicationUser
                {
                    Usuario = empresa.Nome,
                    Email = empresa.Email, 
                    CodigoEmpresa = empresa.CodigoEmpresa,
                    IdUsuario = 0,
                    Admin = true,

                    //UserName = Guid.NewGuid().ToString(),
                    UserName = empresa.Email,
                };

                var result = await _userManager.CreateAsync(user, "SenhaPadrao01$");

                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                    var resultConfirm = await _userManager.ConfirmEmailAsync(user, code);

                    if (resultConfirm.Succeeded)
                    {
                        return Ok("Empresa e usuário criados com sucesso");
                    }
                    else
                    {
                        return Ok(resultConfirm.Errors);
                    }
                }
                else
                {
                    return Ok(result.Errors);
                }
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
