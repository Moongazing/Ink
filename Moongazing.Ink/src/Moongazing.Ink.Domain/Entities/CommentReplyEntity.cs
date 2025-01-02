using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class CommentReplyEntity:Entity<Guid>
{
    public Guid ParentCommentId { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; } = default!;

    public virtual CommentEntity ParentComment { get; set; }
    public virtual UserEntity User { get; set; }
}

