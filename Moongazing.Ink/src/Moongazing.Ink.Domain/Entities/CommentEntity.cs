using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class CommentEntity : Entity<Guid>
{
    public Guid PostId { get; set; }
    public PostEntity Post { get; set; } = default!;
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = default!;
    public string Content { get; set; } = default!;
}
