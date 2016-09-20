using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dezrez.Rezi.Domain.Events;

namespace Dezrez.Rezi.Domain.Roles
{
    public class Role : BaseEntity
    {
        public virtual IList<Event> Events { get; set; }
    }
}
