using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class IdentityResourceClaimMap : BaseEntityMap<IdentityResourceClaim>
    {
        public override void Configure(EntityTypeBuilder<IdentityResourceClaim> builder)
        {
            base.Configure(builder);

            builder.ToTable("IdentityResourceClaim");

            builder.Property(x => x.IdentityResourceId);
            builder.Property(x => x.ClaimTypeId);

            builder.HasOne(x => x.IdentityResource).WithMany(x => x.IdentityResourceClaims);
            builder.HasOne(x => x.ClaimType).WithMany(x => x.IdentityResourceClaims);
        }
    }
}
