using p21pi_web.Entities;

namespace p21pi_web.Services
{
    public interface IAuthService
    {
        string GenerateJWTToken(UniversityUser user);
        string Login(string login, string password);
        bool ValidateCredentials(UniversityUser user, string password);

        UniversityUser Register(string email, string login, string password);
    }
}