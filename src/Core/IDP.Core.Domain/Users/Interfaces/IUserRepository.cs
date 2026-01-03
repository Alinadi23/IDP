using IDP.Core.Domain.Common;
using IDP.Core.Domain.Users.Entities;

namespace IDP.Core.Domain.Users.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> ExistsAsync(string username);
}
