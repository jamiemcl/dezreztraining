using System;
using System.Collections.Generic;
using AutoMapper;
using Dezrez.Rezi.Abstractions.Repository;
using Dezrez.Rezi.Abstractions.Services;
using Dezrez.Rezi.DataContracts.People.Query;
using Dezrez.Rezi.Domain.People;

namespace Dezrez.Rezi.Services.People
{
    public class GroupDomainService : BaseDomainService, IGroupDomainService
    {
        private readonly IRepository _repository;
        private readonly IGroupRepository _groupRepository;

        public GroupDomainService(IRepository repository, IGroupRepository groupRepository)
        {
            _repository = repository;
            _groupRepository = groupRepository;
        }

        public IList<GroupDataContract> GetGroups()
        {
            return Mapper.Map<IList<GroupDataContract>>(_repository.FindAll<Group>());
        }

        public void AddGroup(GroupDataContract groupDataContract)
        {
            Group group = new Group();

            foreach (var groupPerson in groupDataContract.ListOfPeople)
            {
                GroupPerson gp = new GroupPerson
                {
                    RelationshipType = groupPerson.RelationshipType,
                    Person = new Person
                    {
                        Id = groupPerson.Person.Id,
                        Name = groupPerson.Person.Name,
                        Notes = groupPerson.Person.Notes,
                        Deleted = groupPerson.Person.Deleted,
                        CreatedDate = groupPerson.Person.CreatedDate,
                        ContactDetails = new ContactDetail
                        {
                            Email = groupPerson.Person.ContactDetails.Email,
                            PhoneNumber = groupPerson.Person.ContactDetails.PhoneNumber
                        }
                    }
                };

                group.GroupOfPeople.Add(gp);
            }

            _repository.Save(group);
        }

        public IList<Group> GetAllGroupsWithEmailAddress(string email)
        {
            return _groupRepository.GetAllGroupsByEmail(email);
        }
    }
}