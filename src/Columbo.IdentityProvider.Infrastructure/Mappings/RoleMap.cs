using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class RoleMap : ManagedBaseEntityMap<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);

            builder.ToTable("Role");

            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.InstanceId).HasColumnName("InstanceID");
            builder.Property(x => x.RoleTypeId).HasColumnName("RoleTypeID");
        }
    }
}
