using System.Collections.Generic;
using Dezrez.Rezi.DataContracts.People;

namespace Dezrez.Rezi.Abstractions.Services
{
    public interface IPersonDomainService
    {
        IList<PersonDataContract> GetPeople();
        void AddPerson(string name);
    }
}