using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dezrez.Rezi.Domain.People
{
    public class GroupPerson : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual GroupPersonRelationshipType RelationshipType { get; set; }
        public virtual Group Group { get; set; }
        public virtual Person Person { get; set; }
    }
}
