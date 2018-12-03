using Columbo.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Infrastructure.Mappings
{
    public abstract class ManagedBaseEntityMap<TEntity> : BaseEntityMap<TEntity> where TEntity : ManagedBaseEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.UpdateDate).HasColumnType("datetime2");
        }
    }
}
