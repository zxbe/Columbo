using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class IdentityResourceMap : ManagedBaseEntityMap<IdentityResource>
    {
        public override void Configure(EntityTypeBuilder<IdentityResource> builder)
        {
            base.Configure(builder);

            builder.ToTable("IdentityResource");

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.ShowInDiscoveryDocument);
        }
    }
}
