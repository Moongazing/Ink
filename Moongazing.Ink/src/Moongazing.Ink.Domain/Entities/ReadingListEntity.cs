using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class ReadingListEntity:Entity<Guid>
{
    public string Name { get; set; } = default!;
    public Guid UserId { get; set; }
   public UserEntity User { get; set; }
    public ICollection<PostEntity> Posts { get; set; }
}
