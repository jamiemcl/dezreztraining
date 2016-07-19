using System;
using System.Collections.Generic;
using AutoMapper;
using Dezrez.Rezi.Abstractions.Repository;
using Dezrez.Rezi.Abstractions.Services;
using Dezrez.Rezi.DataContracts.People;
using Dezrez.Rezi.Domain.People;

namespace Dezrez.Rezi.Services.People
{
    public class PersonDomainService : BaseDomainService, IPersonDomainService
    {
        private readonly IRepository _repository;

        public PersonDomainService(IRepository repository)
        {
            _repository = repository;
        }

        public IList<PersonDataContract> GetPeople()
        {
            var people = _repository.FindAll<Person>();
            return Mapper.Map<IList<PersonDataContract>>(people);
        }

        public void AddPerson(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }
            var person = new Person
            {
                Name = name,
                CreatedDate = DateTime.UtcNow
            };
            _repository.Save(person);
        }
    }
}