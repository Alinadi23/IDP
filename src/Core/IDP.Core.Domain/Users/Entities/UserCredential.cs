using IDP.Core.Domain.Users.Enums;

namespace IDP.Core.Domain.Users.Entities;

public class UserCredential
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Username { get; private set; }
    public CredentialType CredentialType { get; private set; }
    public string CredentialDescription { get; private set; }
    public string? PasswordHash { get; private set; }
    public DateTime? PasswordExpiredAt { get; private set; }
    public bool IsActive { get; private set; }

    public UserCredential(string username, CredentialType credentialType, string credentialDescription, string? passwordHash,
        DateTime? passwordExpiredAt)
    {
        Username = username;
        CredentialType = credentialType;
        CredentialDescription = credentialDescription;
        PasswordHash = passwordHash;
        PasswordExpiredAt = passwordExpiredAt;
        IsActive = true;
    }
}
