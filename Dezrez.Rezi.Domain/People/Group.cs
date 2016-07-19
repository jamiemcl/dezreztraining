using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dezrez.Rezi.Domain.People
{
    public class Group : BaseEntity
    {
        public virtual List<GroupPerson> GroupOfPeople { get; set; }
    }
}
