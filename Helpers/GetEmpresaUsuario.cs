using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;

namespace Helpers
{
    public class GetEmpresaUsuario
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetEmpresaUsuario(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetIdEmpresaUsuario()
        {
            var idEmpresaUsuario = 0;
            var identity = _httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity?.Claims;
            foreach (var claim in claims)
            {
                if (claim.Type == "IdEmpresa")
                {
                    idEmpresaUsuario = Convert.ToInt32(claim.Value);
                }
            }
            return idEmpresaUsuario;
        }
    }
}
