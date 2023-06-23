﻿using Entitities.Entidades;
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
        [HttpPost("/api/AdicionarUsuario")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password) || string.IsNullOrWhiteSpace(login.CODEMP))
            {
                return Ok("Falta alguns dados");
            }

            var user = new ApplicationUser 
            { 
                UserName = login.Email, 
                Email = login.Email, 
                CODEMP = login.CODEMP 
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
    }

    

}
