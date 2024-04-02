using ContactService.Models;

namespace ContactService.Token
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}