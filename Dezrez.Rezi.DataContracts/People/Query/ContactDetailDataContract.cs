using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dezrez.Rezi.DataContracts.People.Query
{
    public class ContactDetailDataContract : BaseDataContract
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
