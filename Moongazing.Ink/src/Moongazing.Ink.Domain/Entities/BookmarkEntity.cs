using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class BookmarkEntity : Entity<Guid>
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public virtual UserEntity User { get; set; } = null!;
    public virtual PostEntity Post { get; set; } = null!;
}