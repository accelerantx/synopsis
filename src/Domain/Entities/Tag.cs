using Synopsis.Domain.Common;

namespace Synopsis.Domain.Entities
{
    public class Tag : EntityBase
    {
        public string Name { get; set; }

        public long UserId { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
