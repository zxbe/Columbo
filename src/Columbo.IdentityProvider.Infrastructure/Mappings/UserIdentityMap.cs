using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class UserIdentityMap : AggregateRootMap<UserIdentity>
    {
        public override void Configure(EntityTypeBuilder<UserIdentity> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserIdentity");

            builder.Property(x => x.UserId);
            builder.Property(x => x.Login).HasMaxLength(50);
            builder.Property(x => x.PasswordHash).HasMaxLength(64);
            builder.Property(x => x.IsActive);
        }
    }
}
