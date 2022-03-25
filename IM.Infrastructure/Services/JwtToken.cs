using IM.Application.Interfaces.Services;
using IM.Application.Model;
using IM.Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IM.Infrastructure.Services.JwtToken
{
    public class JwtToken : IJwtToken
    {
        private readonly JwtOptions _options;
        public JwtToken(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        /// <summary>
        /// Overrided Insert Method from GenericRepositoryService, includes User data 
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="email">User Email</param>
        /// <returns>Returns a Jwt token with the defined payload(params)</returns>
        public string Generate(IEnumerable<CustomClaimModel> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _options.Issuer,
                Audience = _options.Audience,
                //Subject = new ClaimsIdentity(new[]
                //{
                //    new Claim(ClaimTypes.Email, email),
                //    new Claim(type: "Id", value: id.ToString())
                //}),
                Subject = new ClaimsIdentity(GetClaims(claims)),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private IEnumerable<Claim> GetClaims(IEnumerable<CustomClaimModel> claims)
        {
            var claimList = new List<Claim>();
            claims.ToList().ForEach(c =>
            {
                claimList.Add(new Claim(type: c.Type, value: c.Value));
            });

            return claimList;
        }
    }
}
