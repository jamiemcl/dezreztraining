using System.Collections.Generic;
using Dezrez.Rezi.Abstractions.Repository;
using Dezrez.Rezi.Domain.People;
using NHibernate;
using NHibernate.Criterion;

namespace Dezrez.Rezi.Repository
{
    public class GroupRepository : Repository
    {
  
        public GroupRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IList<Group> GetAllGroupsByEmail(string email)
        {
            ICriteria crit = GetCriteria<Group>();
            crit.CreateAlias("GroupOfPeople", "groupOfPeople");
            crit.CreateAlias("groupOfPeople.Person", "person");
            crit.CreateAlias("person.ContactDetails", "contactDetails");

            crit.Add(Restrictions.Eq("contactDetails.Email", email));

            return crit.List<Group>();
        }
    }
}
