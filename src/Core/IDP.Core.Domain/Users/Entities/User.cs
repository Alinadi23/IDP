using System.Net;

namespace IDP.Core.Domain.Users.Entities;

public class User
{
    public Guid Id { get; private set; }
    public int TokenVersion { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsLocked { get; private set; }
    private readonly List<UserCredential> _userCredentials = new();
    public IReadOnlyCollection<UserCredential> UserCredentials => _userCredentials;

    public User(UserCredential credential)
    {
        TokenVersion = 1;
        IsActive = true;
        IsLocked = false;
        AddCredential(credential);
    }

    public void AddCredential(UserCredential credential)
    {
        if (credential is null)
            throw new ArgumentNullException(nameof(credential));

        _userCredentials.Add(credential);
    }
}
