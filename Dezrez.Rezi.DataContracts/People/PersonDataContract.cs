using Dezrez.Rezi.Domain.People;

namespace Dezrez.Rezi.DataContracts.People
{
    public class PersonDataContract : BaseDataContract
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public ContactDetail ContactDetails { get; set; }
    }
}