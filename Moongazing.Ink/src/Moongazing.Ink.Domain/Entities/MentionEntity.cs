using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class MentionEntity:Entity<Guid>
{
    public Guid MentionedUserId { get; set; }
    public Guid? PostId { get; set; }
    public Guid? CommentId { get; set; }
    public UserEntity MentionedUser { get; set; }
    public PostEntity Post { get; set; }
    public CommentEntity Comment { get; set; }
}
