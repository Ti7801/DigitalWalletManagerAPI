using BibliotecaBusiness.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace DigitalWalletManagerAPI.Services
{
    public class JwtGeneratorService
    {
        private readonly JwtSettings _appSettings;

        public JwtGeneratorService(JwtSettings appSettings) 
        {
            _appSettings = appSettings;
        }


        public string GerarJwt()
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Segredo);
            var tokenHandler = new JsonWebTokenHandler();
            string token = tokenHandler.CreateToken(new SecurityTokenDescriptor()
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.Audiencia,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return token;
        }
    }
}
