﻿using System;

namespace Synopsis.Domain.Common
{
    public abstract class EntityBase : IEntity
    {
        public long Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
