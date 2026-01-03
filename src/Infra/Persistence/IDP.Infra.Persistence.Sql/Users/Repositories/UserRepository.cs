using IDP.Core.Domain.Users.Interfaces;
using IDP.Infra.Persistence.Sql.Common;
using Microsoft.EntityFrameworkCore;

namespace IDP.Infra.Persistence.Sql.Users.Repositories;
public class UserRepository : IUserRepository
{
    private readonly IdpDbContext _dbContext;

    public UserRepository(IdpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> ExistsAsync(string username)
    {
        return _dbContext.Users.AnyAsync(u => u.Username == username);
    }
}

