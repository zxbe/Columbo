using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class UserRoleMap : BaseEntityMap<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserRole");

            builder.Property(x => x.UserIdentityId).HasColumnName("UserIdentityID");
            builder.Property(x => x.RoleId).HasColumnName("RoleID");

            builder.HasOne(x => x.UserIdentity).WithMany(x => x.UserRoles);
            builder.HasOne(x => x.Role).WithMany(x => x.UserRoles);
        }
    }
}
