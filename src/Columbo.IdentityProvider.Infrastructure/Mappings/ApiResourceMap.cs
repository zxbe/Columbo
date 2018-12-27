using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class ApiResourceMap : ManagedBaseEntityMap<ApiResource>
    {
        public override void Configure(EntityTypeBuilder<ApiResource> builder)
        {
            base.Configure(builder);

            builder.ToTable("ApiResource");

            builder.Property(x => x.ApiGuid);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
        }
    }
}
