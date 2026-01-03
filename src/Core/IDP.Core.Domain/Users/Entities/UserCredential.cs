using IDP.Core.Domain.Users.Enums;

namespace IDP.Core.Domain.Users.Entities;

public class UserCredential
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Username { get; private set; }
    public LoginType LoginType { get; private set; }
    public string Identifier { get; private set; }
    public string? PasswordHash { get; private set; }
    public DateTime? PasswordExpiredAt { get; private set; }
    public bool IsActive { get; private set; }

    public UserCredential(string username, LoginType loginType, string identifier, string? passwordHash,
        DateTime? passwordExpiredAt)
    {
        Username = username;
        LoginType = loginType;
        Identifier = identifier;
        PasswordHash = passwordHash;
        PasswordExpiredAt = passwordExpiredAt;
        IsActive = true;
    }
}
