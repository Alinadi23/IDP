using Microsoft.EntityFrameworkCore;


namespace IDP.Infra.Persistence.Sql.Common;

public class IdpDbContext : DbContext
{
    public IdpDbContext(DbContextOptions options) : base(options)
    {
    }
}
