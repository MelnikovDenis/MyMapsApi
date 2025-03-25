using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyMapsApi.App.Implements.TokenService.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyMapsApi.App.Implements.TokenService;

internal class JwtTokenService(IOptions<JwtTokenServiceOptions> options)
{
    private readonly JwtTokenServiceOptions _options = options.Value;

    internal string CreateToken(string name)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expires = DateTime.UtcNow.Add(TimeSpan.FromSeconds(_options.Lifetime));
        var issuedAt = DateTime.UtcNow;

        List<Claim> claims = [
            new Claim("name", name)
        ];

        var token = new JwtSecurityToken(_options.Issuer, null, claims, issuedAt, expires, credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
