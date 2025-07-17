using System.Security.Claims;

namespace POS_System.Security
{
    public interface ITokenManager
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
    }
}
