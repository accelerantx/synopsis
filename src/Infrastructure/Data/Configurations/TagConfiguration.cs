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
        }
    }
}
