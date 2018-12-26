using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class ApiResourceClaimMap : BaseEntityMap<ApiResourceClaim>
    {
        public override void Configure(EntityTypeBuilder<ApiResourceClaim> builder)
        {
            base.Configure(builder);

            builder.ToTable("ApiResourceClaim");

            builder.Property(x => x.ApiResourceId);
            builder.Property(x => x.ClaimTypeId);

            builder.HasOne(x => x.ApiResource).WithMany(x => x.ApiResourceClaims);
            builder.HasOne(x => x.ClaimType).WithMany(x => x.ApiResourceClaims);
        }
    }
}
