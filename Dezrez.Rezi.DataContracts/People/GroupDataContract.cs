using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dezrez.Rezi.Domain.People;

namespace Dezrez.Rezi.DataContracts.People
{
    public class GroupDataContract
    {
        public List<GroupPerson> ListOfPeople { get; set; } 
    }
}
