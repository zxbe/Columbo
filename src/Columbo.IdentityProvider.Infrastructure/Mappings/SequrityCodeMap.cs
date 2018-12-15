using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class SequrityCodeMap : BaseEntityMap<SequrityCode>
    {
        public override void Configure(EntityTypeBuilder<SequrityCode> builder)
        {
            base.Configure(builder);

            builder.ToTable("SequrityCode");

            builder.Property(x => x.SessionId);
            builder.Property(x => x.Code);
        }
    }
}
