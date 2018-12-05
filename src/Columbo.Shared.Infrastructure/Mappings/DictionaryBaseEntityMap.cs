using Columbo.Shared.Kernel.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Columbo.Shared.Infrastructure.Mappings
{
    public abstract class DictionaryBaseEntityMap<TEntity> : BaseEntityMap<TEntity> where TEntity : DictionaryBaseEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasMaxLength(50);
        }
    }
}
