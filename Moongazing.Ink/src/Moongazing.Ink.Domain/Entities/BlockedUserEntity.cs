using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class BlockedUserEntity : Entity<Guid>
{
    public Guid BlockerId { get; set; }
    public Guid BlockedId { get; set; }
    public virtual UserEntity Blocker { get; set; } = null!;
    public virtual UserEntity Blocked { get; set; } = null!;
}