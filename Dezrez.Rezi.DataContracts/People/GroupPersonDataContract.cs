using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dezrez.Rezi.Domain.People;

namespace Dezrez.Rezi.DataContracts.People
{
    public class GroupPersonDataContract
    {
        public GroupPersonRelationshipType RelationshipType { get; set; }
        public Group Group { get; set; }
        public Person Person { get; set; }
    }
}
