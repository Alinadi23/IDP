using IDP.Core.Domain.Users.Enums;

namespace IDP.Core.Domain.Users.Entities;

public class UserCredential
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Username { get; set; }
    public LoginType LoginType { get; set; }
    public required string Identifier { get; set; }
    public string? PasswordHash { get; set; }
    public DateTime? PasswordExpiredAt { get; set; }
    public bool IsActive { get; set; }
}
