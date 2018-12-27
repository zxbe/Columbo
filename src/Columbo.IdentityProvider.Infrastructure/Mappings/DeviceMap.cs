using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Columbo.Shared.Kernel.ValueObjects;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class DeviceMap : ManagedBaseEntityMap<Device>
    {
        public override void Configure(EntityTypeBuilder<Device> builder)
        {
            base.Configure(builder);

            builder.ToTable("Device");
            
            builder.Property(x => x.IpAddress).HasConversion<string>(x => x.ToString(), y => IPAddress.Parse(y)).HasMaxLength(15).IsRequired();
            builder.Property(x => x.MacAddress).HasConversion<string>(x => x.ToString(), y => new MacAddress(y)).HasMaxLength(17).IsRequired();
            builder.Property(x => x.IsActive);
            builder.Property(x => x.DeviceTypeId);

            builder.HasOne(x => x.DeviceType).WithMany(x => x.Devices);
            
        }
    }
}
