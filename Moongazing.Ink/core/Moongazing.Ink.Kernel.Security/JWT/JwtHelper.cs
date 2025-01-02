using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Moongazing.Ink.Domain.Entities;
using Moongazing.Ink.Kernel.Security.Encryption;
using Moongazing.Ink.Kernel.Security.Extensions;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Moongazing.Ink.Kernel.Security.JWT;

public class JwtHelper : ITokenHelper
{
    public IConfiguration Configuration { get; }
    private readonly TokenOptions tokenOptions;
    private DateTime accessTokenExpiration;
    public JwtHelper(IConfiguration configuration)  
    {
        Configuration = configuration;
        const string configurationSection = "TokenOptions";
        tokenOptions =
            Configuration.GetSection(configurationSection).Get<TokenOptions>()
            ?? throw new NullReferenceException($"\"{configurationSection}\" section cannot found in configuration.");
    }
    public AccessToken CreateToken(UserEntity user, IList<OperationClaimEntity> operationClaims)
    {
        accessTokenExpiration = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);
        SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey);
        SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        JwtSecurityToken jwt = CreateJwtSecurityToken(tokenOptions, user, signingCredentials, operationClaims);
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
        string? token = jwtSecurityTokenHandler.WriteToken(jwt);

        Console.WriteLine(token);

        return new AccessToken { Token = token, Expiration = accessTokenExpiration };
    }
    public RefreshTokenEntity CreateRefreshToken(UserEntity user, string ipAddress)
    {
        RefreshTokenEntity refreshToken =
            new()
            {
                UserId = user.Id,
                Token = RandomRefreshToken(),
                Expires = DateTime.UtcNow.AddDays(7),
                CreatedByIp = ipAddress
            };

        return refreshToken;
    }
    public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,
                                                   UserEntity user,
                                                   SigningCredentials signingCredentials,
                                                   IList<OperationClaimEntity> operationClaims)
    {
        JwtSecurityToken jwt =
            new(
                tokenOptions.Issuer,
                tokenOptions.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
        return jwt;
    }

    protected virtual IEnumerable<Claim> SetClaims(UserEntity user, IList<OperationClaimEntity> operationClaims)
    {
        List<Claim> claims = [];
        claims.AddNameIdentifier(user!.Id!.ToString()!);
        claims.AddEmail(user.Email);
        claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
        return claims.ToImmutableList();
    }

    private static string RandomRefreshToken()
    {
        byte[] numberByte = new byte[32];
        using var random = RandomNumberGenerator.Create();
        random.GetBytes(numberByte);
        return Convert.ToBase64String(numberByte);
    }
}
