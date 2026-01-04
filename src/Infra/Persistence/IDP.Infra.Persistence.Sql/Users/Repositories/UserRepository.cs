using IDP.Core.Domain.Common;
using IDP.Core.Domain.Users.Entities;
using IDP.Core.Domain.Users.Interfaces;
using IDP.Infra.Persistence.Sql.Common;
using Microsoft.EntityFrameworkCore;

namespace IDP.Infra.Persistence.Sql.Users.Repositories;
public class UserRepository : BaseRepository<User, IdpDbContext>, IUserRepository
{
    public UserRepository(IdpDbContext dbContext) : base(dbContext)
    {
    }

    public Task<bool> ExistsAsync(string username)
    {
        return _dbContext.UserCredentials
            .AnyAsync(u => u.Username == username);
    }
}

