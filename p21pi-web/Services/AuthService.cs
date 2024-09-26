using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using p21pi_web.Constants;
using p21pi_web.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace p21pi_web.Services
{
    public class AuthService : IAuthService
    {
        private readonly string secretKey = "S3cr3t_K3y!_S3cr3t_K3y!_S3cr3t_K3y!_";
        private readonly UserManager<UniversityUser> _userManager;

        public AuthService(UserManager<UniversityUser> userManager)
        {
            _userManager = userManager;
        }

        public string GenerateJWTToken(UniversityUser user)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(AuthConstants.StudentIdClaimType, user.StudentId.ToString()),
                };

            var userRoles = _userManager.GetRolesAsync(user).Result;
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(
                   Encoding.UTF8.GetBytes(secretKey));

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(
                    authSigningKey,
                                    SecurityAlgorithms.HmacSha256)
                                );

            var result = new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }

        public bool ValidateCredentials(UniversityUser user, string password)
        {
            return _userManager.CheckPasswordAsync(user, password).Result;
        }

        public string Login(string login, string password)
        {
            var user = _userManager.FindByNameAsync(login)
                .Result;

            if (user is null || !ValidateCredentials(user, password))
            {
                throw new Exception("Wrong login or password");
            }

            return GenerateJWTToken(user);
        }

        public UniversityUser Register(string email, string login, string password)
        {
            var user = _userManager.FindByNameAsync(login)
                .Result;

            if (user is not null)
            {
                throw new Exception("User already exist");
            }

            user = new UniversityUser()
            {
                Email = email,
                UserName = login,
            };

            var result = _userManager.CreateAsync(user, password).Result;

            if (!result.Succeeded)
            {
                var errorsText = string.Join(",",                    
                    result.Errors
                    .Select(e => e.Description));
                throw new Exception($"Errors during user creation: {errorsText}");
            }

            return user;
        }
    }
}
