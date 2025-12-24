using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IDP.Core.Domain.RefreshTokens.Entities;

namespace IDP.Infra.Persistence.Sql.RefreshTokens.Configs;

public class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {


    }
}
