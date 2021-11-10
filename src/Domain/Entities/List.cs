using System.Collections.Generic;
using Synopsis.Domain.Common;

namespace Synopsis.Domain.Entities
{
    public class List : EntityBase
    {
        public string Name { get; set; }

        public long UserId { get; set; }
        public virtual UserProfile User { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }
    }
}
