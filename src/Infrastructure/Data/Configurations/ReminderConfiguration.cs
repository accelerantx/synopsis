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

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.DueDate)
                .IsOptional();

            builder.Property(e => e.Priority)
                .IsRequired();

            builder.Property(e => e.Completed)
                .IsOptional();

            builder.Property(e => e.Notes)
                .IsOptional()
                .HasMaxLength(2000);

            builder.Property(e => e.Url)
                .IsOptional()
                .HasMaxLength(2000);

            builder.HasMany(e => e.Tags)
                .WithRequired(t => t.Reminder)
                .HasForeignKey(e => e.ReminderId);

            builder.HasRequired(e => e.User)
                .WithMany(u => u.Reminders)
                .HasForeignKey(e => e.UserId);

            builder.HasRequired(e => e.List)
                .WithMany(l => l.Reminders)
                .HasForeignKey(e => e.ListId);
        }
    }
}
