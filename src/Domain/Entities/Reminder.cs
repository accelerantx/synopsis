using System;
using System.Collections.Generic;
using Synopsis.Domain.Common;
using Synopsis.Domain.Enums;

namespace Synopsis.Domain.Entities
{
    public class Reminder : EntityBase
    {
        public string Title { get; set; }
        public DateTime? DueDate { get; set; }
        public string Notes { get; set; }
        public string Url { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool? Completed { get; set; }
        public long ListId { get; set; }
        public long UserId { get; set; }

        public virtual ICollection<ReminderTag> Tags { get; set; }
        public virtual List List { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
