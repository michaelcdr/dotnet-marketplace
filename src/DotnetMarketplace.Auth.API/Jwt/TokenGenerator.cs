using DotnetMarketplace.Auth.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotnetMarketplace.Auth.API.Jwt
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtAppSettings _jwtConfig;
        private readonly ILogger<TokenGenerator> _logger;

        public TokenGenerator(UserManager<IdentityUser> userManager,
                              IOptions<JwtAppSettings> optionsMonitor,
                              ILogger<TokenGenerator> logger)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.Value;
            _logger = logger;

        }

        public async Task<TokenGeneratedResponse?> Generate(string userName)
        {
            IdentityUser? identityUser = await _userManager.FindByNameAsync(userName);

            if (identityUser == null)
            {
                _logger.LogWarning($"O usuario {userName} não foi encontrado.");
                return null;
            }

            var userRoles = await _userManager.GetRolesAsync(identityUser);

            if (userRoles == null || userRoles.Count == 0)
            {
                _logger.LogWarning($"O usuario {userName} não contem roles.");
                return null;
            }

            var claimsIdentity = new ClaimsIdentity(await GetClaims(identityUser, userRoles));

            string encondedToken = CreateEncondedToken(claimsIdentity);

            var response = new TokenGeneratedResponse
            {
                AccessToken = encondedToken,
                ExpiresIn = TimeSpan.FromHours(_jwtConfig.ExpiresIn).TotalSeconds,
                UserToken = new UserToken
                {
                    Id = identityUser.Id,
                    Email = identityUser.Email,
                    UserName = identityUser.UserName,
                    Claims = claimsIdentity.Claims.Select(c => new UserClaim
                    {
                        Type = c.Type,
                        Value = c.Value

                    }).ToList(),
                }
            };

            return response;
        }

        private string CreateEncondedToken(ClaimsIdentity claimsIdentity)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience,
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtConfig.Secret)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            string encondedToken = tokenHandler.WriteToken(token);
            return encondedToken;
        }

        private async Task<IList<Claim>> GetClaims(IdentityUser identityUser, IList<string> userRoles)
        {
            var claims = await _userManager.GetClaimsAsync(identityUser);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, identityUser.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, identityUser.Email ?? string.Empty));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var role in userRoles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            return claims;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}