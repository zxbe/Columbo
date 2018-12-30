using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class InstanceMap : ManagedBaseEntityMap<Instance>
    {
        public override void Configure(EntityTypeBuilder<Instance> builder)
        {
            base.Configure(builder);

            builder.ToTable("Instance");

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
        }
    }
}
