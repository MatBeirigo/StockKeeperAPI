using Domain.Servicos;
using Entitities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Models;
using WebApi.Token;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public TokenController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] InputModel Input, bool RememberMe)
        {
            if (string.IsNullOrWhiteSpace(Input.Email) || string.IsNullOrWhiteSpace(Input.Password))
            {
                return Unauthorized();
            }

            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                var idEmpresa = user?.IdEmpresa;

                var claims = new[]
                {
                    new Claim("IdEmpresa", idEmpresa.ToString()),
                };

                var tokenKey = "Your_Secret_Key-12345678";
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Teste.Security.Bearer",
                    audience: "Teste.Security.Bearer",
                    claims: claims,
                    expires: DateTime.Now.AddDays(7),
                    signingCredentials: credentials
                );

                var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(tokenValue);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}