namespace IDP.Core.Domain.Users.Entities;

public class User
{
    public Guid Id { get; set; }
    public int TokenVersion { get; set; }
    public bool IsActive { get; set; }
    public bool IsLocked { get; set; }
    public required string Username { get; set; }
}
