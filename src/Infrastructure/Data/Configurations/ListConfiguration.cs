using System.Data.Entity.ModelConfiguration;
using Synopsis.Domain.Entities;

namespace Synopsis.Infrastructure.Data.Configurations
{
    internal class ListConfiguration : ConfigurationBase<List>
    {
        public override string TableName => "Lists";

        public override void Configure(EntityTypeConfiguration<List> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasRequired(e => e.User)
                .WithMany(u => u.Lists)
                .HasForeignKey(e => e.UserId);
        }
    }
}
