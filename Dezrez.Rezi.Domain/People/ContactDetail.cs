using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dezrez.Rezi.Domain.People
{
    public class ContactDetail : BaseEntity
    {
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
    }
}
