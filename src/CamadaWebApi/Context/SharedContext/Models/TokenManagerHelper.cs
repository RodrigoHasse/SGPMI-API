using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CamadaWebApi.Context.SharedContext.Models
{
    public class TokenManagerHelper
    {
        private readonly AppSettingsHelper _appSettings;

        public TokenManagerHelper(IOptions<AppSettingsHelper> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public JwtSecurityToken GetJwtSecurityToken(int id, string login, string perfil, string nome)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, nome),
                    new Claim(ClaimTypes.Role, perfil),
                    new Claim("ID", id.ToString()), 
                    new Claim("LOGIN", login)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityToken token = (JwtSecurityToken)tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
