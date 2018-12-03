using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class UserDeviceMap : ManagedBaseEntityMap<UserDevice>
    {
        public override void Configure(EntityTypeBuilder<UserDevice> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserDevice");
            builder.Property(x => x.UserIdentityId).HasColumnName("UserIdentityID");
            builder.Property(x => x.DeviceId).HasColumnName("DeviceID");
            builder.Property(x => x.IsCodeRequired);
        }
    }
}
