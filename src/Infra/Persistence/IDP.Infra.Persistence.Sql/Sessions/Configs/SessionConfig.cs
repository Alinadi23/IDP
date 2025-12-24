
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IDP.Core.Domain.Sessions.Entities;

namespace IDP.Infra.Persistence.Sql.Sessions.Configs;

public class SessionConfig : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {


    }
}

