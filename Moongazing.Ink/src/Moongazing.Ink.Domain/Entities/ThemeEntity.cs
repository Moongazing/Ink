using Moongazing.Ink.Domain.Enums;
using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class ThemeEntity : Entity<Guid>
{
    public int UserId { get; set; }
    public ThemeType ThemeName { get; set; } = default!;
}
