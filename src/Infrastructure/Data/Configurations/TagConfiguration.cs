using System.Data.Entity.ModelConfiguration;
using Synopsis.Domain.Entities;

namespace Synopsis.Infrastructure.Data.Configurations
{
    internal class TagConfiguration : ConfigurationBase<Tag>
    {
        public override string TableName => "Tags";

        public override void Configure(EntityTypeConfiguration<Tag> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasRequired(e => e.User)
                .WithMany(u => u.Tags)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
