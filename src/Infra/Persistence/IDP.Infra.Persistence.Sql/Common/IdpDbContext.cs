using IDP.Core.ApplicationService.Common.Interfaces.CurrentService;
using IDP.Core.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace IDP.Infra.Persistence.Sql.Common;

public class IdpDbContext : DbContext
{
    private readonly ICurrentUserService? _currentUserService;

    public IdpDbContext()
    {
        
    }
    public IdpDbContext(DbContextOptions<IdpDbContext> options, ICurrentUserService? currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {

            builder.Entity(entityType.ClrType).Property<DateTime>("CreatedAt");
            builder.Entity(entityType.ClrType).Property<string>("CreatedBy").HasMaxLength(50);
            builder.Entity(entityType.ClrType).Property<DateTime?>("ModifiedAt");
            builder.Entity(entityType.ClrType).Property<string>("ModifiedBy").HasMaxLength(50);
        }

        base.OnModelCreating(builder);
        builder.UseOpenIddict();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }

    public override int SaveChanges()
    {
        ApplyAudit();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAudit();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAudit()
    {
        var now = DateTime.UtcNow;
        var userId = _currentUserService?.UserId ?? "System";

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedAt").CurrentValue = now;
                entry.Property("CreatedBy").CurrentValue = userId;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("UpdatedAt").CurrentValue = now;
                entry.Property("UpdatedBy").CurrentValue = userId;
            }
        }
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserCredential> UserCredentials { get; set; }

}
