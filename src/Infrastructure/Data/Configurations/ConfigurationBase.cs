
using System.Data.Entity.ModelConfiguration;
using Synopsis.Domain.Common;

// TODO: use these instead when upgrading to EF Core
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Synopsis.Infrastructure.Data.Configurations
{
    internal abstract class ConfigurationBase<TEntity> 
    // TODO: inherit from this when upgrade to EF Core
    // : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity
    {
        public abstract string TableName { get; }

        // TODO: this becomes EntityTypeBuilder<TEntity> when upgrading to EF Core
        public virtual void Configure(EntityTypeConfiguration<TEntity> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.IsDeleted)
                .IsOptional();
        }
    }
}
