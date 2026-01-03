using IDP.Core.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;


namespace IDP.Infra.Persistence.Sql.Common;

public class IdpDbContext : DbContext
{
    public IdpDbContext()
    {
        
    }
    public IdpDbContext(DbContextOptions<IdpDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.UseOpenIddict();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserCredential> UserCredentials { get; set; }

}
