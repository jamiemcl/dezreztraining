using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dezrez.Rezi.Domain.Events;

namespace Dezrez.Rezi.DataContracts.Roles
{
    public class RoleDataContract
    {
        public List<Event> Events { get; set; } 
    }
}
