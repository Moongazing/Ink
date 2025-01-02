using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class CategoryEntity : Entity<Guid>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public virtual ICollection<PostEntity> Posts { get; set; } = new HashSet<PostEntity>();

}
