using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class VirtualEventEntity : Entity<Guid>
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime ScheduledAt { get; set; } = default!;
    public string EventLink { get; set; } = default!;
    public Guid HostUserId { get; set; }
    public virtual UserEntity HostUser { get; set; } = default!;
}
