using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class ClientIdentityResourceMap : BaseEntityMap<ClientIdentityResource>
    {
        public override void Configure(EntityTypeBuilder<ClientIdentityResource> builder)
        {
            base.Configure(builder);

            builder.ToTable("ClientIdentityResource");

            builder.Property(x => x.ClientId);
            builder.Property(x => x.IdentityResourceId);

            builder.HasOne(x => x.Client).WithMany(x => x.ClientIdentityResources);
            builder.HasOne(x => x.IdentityResource).WithMany(x => x.ClientIdentityResources);
        }
    }
}
