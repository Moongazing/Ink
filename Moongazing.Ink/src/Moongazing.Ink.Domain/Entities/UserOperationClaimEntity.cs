using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class UserOperationClaimEntity : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
    public virtual UserEntity User { get; set; } = null!;
    public virtual OperationClaimEntity OperationClaim { get; set; } = null!;

    public UserOperationClaimEntity()
    {

    }
    public UserOperationClaimEntity(Guid userId, Guid operationClaimId)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
    public UserOperationClaimEntity(Guid id, Guid userId, Guid operationClaimId)
        : base()
    {
        Id = id;
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}