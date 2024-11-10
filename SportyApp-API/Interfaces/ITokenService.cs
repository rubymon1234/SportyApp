using SportyApp.Models;

namespace SportyApp.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(AppUser user);
    }
}
