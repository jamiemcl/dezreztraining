using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dezrez.Rezi.Domain;
using Dezrez.Rezi.Domain.Roles;

namespace Dezrez.Rezi.DataContracts.Events
{
    public class EventDataContract
    {
        public List<Role> Roles { get; set; } 
    }
}
