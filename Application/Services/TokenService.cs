using api_csharp.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_csharp.Application.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(User user, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Lendo os dados na configurações em appsettings.json
            var secretKey = _configuration["JwtSettings:SecretKey"]!;
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];
            var expiryMinutes = double.Parse(_configuration["JwtSettings:ExpiryInMinutes"]!);

            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                // Subject identificador principal (O ID do usuário)
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                
                // Nome único/E-mail para identificação rápida
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email.Address),
                
                // ID único do Token 
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                
                // A Role para o controle de acesso RBAC
                new Claim(ClaimTypes.Role, role)
            };

            // Montando a estrutura do token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expiryMinutes), // Tempo de Expiração
                Issuer = issuer,
                Audience = audience,
                // Assinatura digital usando algoritmo SHA256 com a nossa chave secreta
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            //Cria e encripta o token transformando-o na string gigante(JWT)
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
