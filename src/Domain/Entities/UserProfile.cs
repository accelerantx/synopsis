using System.Collections.Generic;
using Synopsis.Domain.Common;

namespace Synopsis.Domain.Entities
{
    public class UserProfile : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<List> Lists { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }
    }
}
