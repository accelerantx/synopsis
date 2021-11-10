using System.Data.Entity.ModelConfiguration;
using Synopsis.Domain.Entities;

namespace Synopsis.Infrastructure.Data.Configurations
{
    internal class ReminderConfiguration : ConfigurationBase<Reminder>
    {
        public override string TableName => "Reminders";

        public override void Configure(EntityTypeConfiguration<Reminder> builder)
        {
            base.Configure(builder);
        }
    }
}
