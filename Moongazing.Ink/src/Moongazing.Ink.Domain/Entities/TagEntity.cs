using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class TagEntity : Entity<Guid>
{
    public string Name { get; set; } = default!;
    public virtual ICollection<PostEntity> Posts { get; set; } = new HashSet<PostEntity>();
}
