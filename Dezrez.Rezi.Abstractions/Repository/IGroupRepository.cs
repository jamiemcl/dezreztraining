using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dezrez.Rezi.Domain.People;

namespace Dezrez.Rezi.Abstractions.Repository
{
    public interface IGroupRepository
    {
        IList<Group> GetAllGroupsByEmail(string email);
    }
}
