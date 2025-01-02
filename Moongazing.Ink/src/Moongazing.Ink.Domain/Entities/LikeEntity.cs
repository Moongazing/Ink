using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class LikeEntity : Entity<Guid>
{
    public Guid PostId { get; set; }
    public virtual PostEntity Post { get; set; } = default!;
    public Guid UserId { get; set; }
    public virtual UserEntity User { get; set; } = default!;
}
