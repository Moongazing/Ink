namespace Moongazing.Ink.Kernel.Application.Dtos;

public class RegisterDto : IDto
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}