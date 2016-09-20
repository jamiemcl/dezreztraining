using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dezrez.Rezi.Domain.People;

namespace Dezrez.Rezi.DataContracts.People.Query
{
    public class GroupPersonDataContract : BaseDataContract
    {
        public GroupPersonRelationshipType RelationshipType { get; set; }
        public GroupDataContract Group { get; set; }
        public PersonDataContract Person { get; set; }
    }
}
