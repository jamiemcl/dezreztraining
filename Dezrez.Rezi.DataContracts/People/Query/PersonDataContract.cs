using Dezrez.Rezi.Domain.People;

namespace Dezrez.Rezi.DataContracts.People.Query
{
    public class PersonDataContract : BaseDataContract
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public ContactDetailDataContract ContactDetails { get; set; }
    }
}