using Moongazing.Ink.Domain.Enums;
using Moongazing.Ink.Kernel.Persistence.Repositories;

namespace Moongazing.Ink.Domain.Entities;

public class UserEntity : Entity<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public byte[] PasswordSalt { get; set; } = default!;
    public byte[] PasswordHash { get; set; } = default!;
    public AuthenticatorType AuthenticatorType { get; set; }
    public string Username { get; set; } = default!;
    public string? ProfilePicture { get; set; }
    public string? Biography { get; set; }
    public string? SocialLinks { get; set; }
    public bool IsActive { get; set; }
    public ICollection<FollowEntity> Followers { get; set; } = new HashSet<FollowEntity>();
    public ICollection<FollowEntity> Followings { get; set; } = new HashSet<FollowEntity>();
    public virtual ICollection<UserOperationClaimEntity> UserOperationClaims { get; set; } = new HashSet<UserOperationClaimEntity>();
    public virtual ICollection<RefreshTokenEntity> RefreshTokens { get; set; } = new HashSet<RefreshTokenEntity>();
    public virtual ICollection<EmailAuthenticatorEntity> EmailAuthenticators { get; set; } = new HashSet<EmailAuthenticatorEntity>();
    public virtual ICollection<OtpAuthenticatorEntity> OtpAuthenticators { get; set; } = new HashSet<OtpAuthenticatorEntity>();
}
