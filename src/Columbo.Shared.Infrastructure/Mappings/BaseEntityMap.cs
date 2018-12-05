using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Columbo.Shared.Kernel.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Columbo.Shared.Infrastructure.Mappings
{
    public abstract class BaseEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatorId).HasColumnName("CreatorID");
            builder.Property(x => x.CreateDate).HasColumnType("datetime2");
        }
    }
}
