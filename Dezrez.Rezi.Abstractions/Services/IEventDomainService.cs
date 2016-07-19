using System.Collections.Generic;
using Dezrez.Rezi.DataContracts.Events;

namespace Dezrez.Rezi.Abstractions.Services
{
    public interface IEventDomainService
    {
        IList<EventDataContract> GetEvents();
        void AddEvent(EventDataContract e);
    }
}
