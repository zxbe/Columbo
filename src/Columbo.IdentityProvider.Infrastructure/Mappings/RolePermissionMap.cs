using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class RolePermissionMap : BaseEntityMap<RolePermission>
    {
        public override void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            base.Configure(builder);

            builder.ToTable("RolePermission");

            builder.Property(x => x.RoleId).HasColumnName("RoleID");
            builder.Property(x => x.PermissionId).HasColumnName("PermissionID");
        }
    }
}
