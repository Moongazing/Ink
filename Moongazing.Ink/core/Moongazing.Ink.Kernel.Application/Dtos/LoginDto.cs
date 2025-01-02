namespace Moongazing.Ink.Kernel.Application.Dtos;

public class LoginDto : IDto
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string? AuthenticatorCode { get; set; }
}
