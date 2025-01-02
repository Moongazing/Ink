using Moongazing.Ink.Domain.Enums;
using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class ReportEntity : Entity<Guid>
{
    public int? PostId { get; set; }
    public int? CommentId { get; set; }
    public int UserId { get; set; }
    public string Reason { get; set; } = default!;
    public ReportType Type { get; set; } = default!;
    public virtual PostEntity Post { get; set; } = null!;
    public virtual CommentEntity Comment { get; set; } = null!;
    public virtual UserEntity User { get; set; } = null!;
}
