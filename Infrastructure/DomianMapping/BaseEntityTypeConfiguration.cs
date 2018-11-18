using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DomianMapping
{
    public partial class BaseEntityTypeConfiguration<TEntity> : IMapConfiguration,IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        protected virtual void PostConfigure(EntityTypeBuilder<TEntity> builder)
        {
        }
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            this.PostConfigure(builder);
        }

        public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }

    }
}
