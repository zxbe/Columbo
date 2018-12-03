using Columbo.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Infrastructure.Mappings
{
    public abstract class AggregateRootMap<TEntity> : ManagedBaseEntityMap<TEntity> where TEntity : AggregateRoot
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Version);
        }
    }
}
