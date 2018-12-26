using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class ClientApiResourceMap : BaseEntityMap<ClientApiResource>
    {
        public override void Configure(EntityTypeBuilder<ClientApiResource> builder)
        {
            base.Configure(builder);

            builder.ToTable("ClientApiResource");

            builder.Property(x => x.ClientId);
            builder.Property(x => x.ApiResourceId);

            builder.HasOne(x => x.Client).WithMany(x => x.ClientApiResources);
            builder.HasOne(x => x.ApiResource).WithMany(x => x.ClientApiResources);
        }
    }
}
