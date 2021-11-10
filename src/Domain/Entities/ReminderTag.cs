using Synopsis.Domain.Common;

namespace Synopsis.Domain.Entities
{
    public class ReminderTag : EntityBase
    {
        public long ReminderId { get; set; }
        public virtual Reminder Reminder { get; set;  }

        public long TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
