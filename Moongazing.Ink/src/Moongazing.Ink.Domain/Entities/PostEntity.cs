using Moongazing.Ink.Domain.Enums;
using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class PostEntity : Entity<Guid>
{
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string? Summary { get; set; }
    public PostStatus Status { get; set; } = PostStatus.Draft;
    public int CommentCount { get; set; } = 0;
    public Guid AuthorId { get; set; }
    public virtual UserEntity Author { get; set; } = default!;
    public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>();
    public ICollection<LikeEntity> Likes { get; set; } = new HashSet<LikeEntity>();
    public ICollection<CategoryEntity> Categories { get; set; } = new HashSet<CategoryEntity>();
    public ICollection<TagEntity> Tags { get; set; } = new HashSet<TagEntity>();
}
