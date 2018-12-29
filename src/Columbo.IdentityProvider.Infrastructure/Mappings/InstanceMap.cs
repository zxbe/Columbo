using Columbo.IdentityProvider.Core.Domain;
using Columbo.Shared.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.IdentityProvider.Infrastructure.Mappings
{
    public sealed class InstanceMap : DictionaryBaseEntityMap<Instance>
    {
        public override void Configure(EntityTypeBuilder<Instance> builder)
        {
            base.Configure(builder);

            builder.ToTable("Instance");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
