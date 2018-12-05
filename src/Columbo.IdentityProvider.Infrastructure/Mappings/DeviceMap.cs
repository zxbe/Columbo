using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class DeviceMap : ManagedBaseEntityMap<Device>
    {
        public override void Configure(EntityTypeBuilder<Device> builder)
        {
            base.Configure(builder);

            builder.ToTable("Device");

            builder.Property(x => x.IpAddress.ToString()).HasColumnName("IpAddress");
            builder.Property(x => x.MacAddress.ToString()).HasColumnName("MacAddress");
            builder.Property(x => x.IsActive);
            builder.Property(x => x.DeviceTypeId);

            builder.HasOne(x => x.DeviceType).WithMany(x => x.Devices);
        }
    }
}
