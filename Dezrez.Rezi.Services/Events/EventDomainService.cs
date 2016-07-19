using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dezrez.Rezi.Abstractions.Repository;
using Dezrez.Rezi.Abstractions.Services;
using Dezrez.Rezi.DataContracts.Events;
using Dezrez.Rezi.Domain.Events;

namespace Dezrez.Rezi.Services.Events
{
    public class EventDomainService : BaseDomainService, IEventDomainService
    {
        private readonly IRepository _repository;

        public EventDomainService(IRepository repository)
        {
            _repository = repository;
        }

        public IList<EventDataContract> GetEvents()
        {
            var events = _repository.FindAll<Event>();
            return Mapper.Map<IList<EventDataContract>>(events);
        }

        public void AddEvent(EventDataContract e)
        {
            Event ev = Mapper.Map<Event>(e);
            _repository.Save(ev);
        }
    }
}
