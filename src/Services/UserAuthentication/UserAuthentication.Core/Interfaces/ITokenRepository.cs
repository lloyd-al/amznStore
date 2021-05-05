using System.Security.Claims;
using System.Threading.Tasks;
using amznStore.Services.UserAuthentication.Core.Entities;

namespace amznStore.Services.UserAuthentication.Core.Interfaces
{
    public interface ITokenRepository
    {
        string GenerateSecureSecret();
        Task<string> GenerateJwtToken(ApplicationUser user);
        RefreshToken GenerateRefreshToken(string ipAddress);
        string RandomTokenString();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
