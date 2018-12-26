using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class ClaimTypeMap : DictionaryBaseEntityMap<ClaimType>
    {
        public override void Configure(EntityTypeBuilder<ClaimType> builder)
        {
            base.Configure(builder);

            builder.ToTable("ClaimType");
        }
    }
}
