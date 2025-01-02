using Moongazing.Ink.Domain.Entities;

namespace Moongazing.Ink.Kernel.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(UserEntity user, IList<OperationClaimEntity> operationClaims);
    RefreshTokenEntity CreateRefreshToken(UserEntity user, string ipAddress);
}
