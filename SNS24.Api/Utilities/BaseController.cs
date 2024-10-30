using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SNS24.WebApi.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected Guid UserId
        {
            get
            {
                var userIdClaim = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
                return string.IsNullOrEmpty(userIdClaim) ? Guid.Empty : Guid.Parse(userIdClaim);
            }
        }

        protected string DocumentNumber => User.FindFirst(JwtRegisteredClaimNames.UniqueName)?.Value ?? string.Empty;

        protected string UserRole => User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty;

        protected bool IsInRole(string role) => User.IsInRole(role);

        protected string GetClaim(string claimType)
        {
            return User.FindFirst(claimType)?.Value ?? string.Empty;
        }
    }
}
