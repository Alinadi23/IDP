using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IDP.Core.Domain.Users.Entities;

namespace IDP.Infra.Persistence.Sql.Users.Configs;

public class UserCredentialConfig : IEntityTypeConfiguration<UserCredential>
{
    public void Configure(EntityTypeBuilder<UserCredential> builder)
    {
        builder.ToTable("UserCredentials");
        builder.HasKey(b => b.Id);

    }
}
