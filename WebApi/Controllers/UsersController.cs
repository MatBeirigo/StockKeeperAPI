using Entitities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastroUsuarioSistema")]
        public async Task<IActionResult> CadastroUsuarioSistema([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password) || string.IsNullOrWhiteSpace(login.CodigoEmpresa))
            {
                return Ok("Falta alguns dados");
            }

            var user = new ApplicationUser 
            {
                Usuario = login.Usuario, 
                Email = login.Email,
                CodigoEmpresa = login.CodigoEmpresa,

                UserName = login.Email,
            };

            var result = await _userManager.CreateAsync(user, login.Password);

            if(result.Errors.Any())
            {
                return Ok(result.Errors);
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var resultConfirm = await _userManager.ConfirmEmailAsync(user, code);

            if(resultConfirm.Succeeded)
            {
                return Ok("Usuário criado com sucesso");
            }
            else
            {
                return Ok(resultConfirm.Errors);
            }
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastroEmpresaSistema")]
        public async Task<IActionResult> CadastroEmpresaSistema([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.CodigoEmpresa))
            {
                return Ok("Falta o código da empresa");
            }

            var user = new ApplicationUser
            {
                Usuario = login.Usuario,
                CodigoEmpresa = login.CodigoEmpresa,

                UserName = login.Email,
            };

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                return Ok("Usuário criado com sucesso usando o código da empresa");
            }
            else
            {
                return Ok(result.Errors);
            }
        }
    }
}
