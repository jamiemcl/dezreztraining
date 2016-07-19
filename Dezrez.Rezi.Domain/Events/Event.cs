using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dezrez.Rezi.Domain.Roles;

namespace Dezrez.Rezi.Domain.Events
{
    public class Event : BaseEntity
    {
        public virtual List<Role> Roles { get; set; }
    }
}
