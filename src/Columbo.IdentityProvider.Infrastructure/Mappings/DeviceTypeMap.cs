using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class DeviceTypeMap : DictionaryBaseEntityMap<DeviceType>
    {
        public override void Configure(EntityTypeBuilder<DeviceType> builder)
        {
            base.Configure(builder);

            builder.ToTable("DeviceType");
        }
    }
}
