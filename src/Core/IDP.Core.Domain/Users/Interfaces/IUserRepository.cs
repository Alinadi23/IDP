namespace IDP.Core.Domain.Users.Interfaces;

public interface IUserRepository
{
    Task<bool> ExistsAsync(string username);
}
