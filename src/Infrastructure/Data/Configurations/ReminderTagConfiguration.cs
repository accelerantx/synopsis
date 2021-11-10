using System.Data.Entity.ModelConfiguration;
using Synopsis.Domain.Entities;

namespace Synopsis.Infrastructure.Data.Configurations
{
    internal class ReminderTagConfiguration : ConfigurationBase<ReminderTag>
    {
        public override string TableName => "ReminderTags";

        public override void Configure(EntityTypeConfiguration<ReminderTag> builder)
        {
            base.Configure(builder);
        }
    }
}
