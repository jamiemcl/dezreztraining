using System;

namespace Dezrez.Rezi.Domain
{
    public class BaseEntity
    {
        public virtual long Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual bool Deleted { get; set; }
    }
}