using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class FollowEntity : Entity<Guid>
{
    public Guid FollowerId { get; set; }
    public UserEntity Follower { get; set; } = default!;
    public Guid FollowingId { get; set; }
    public UserEntity Following { get; set; } = default!;
}
