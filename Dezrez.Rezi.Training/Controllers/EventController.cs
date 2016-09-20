using System.Collections.Generic;
using System.Web.Http;
using Dezrez.Rezi.Abstractions.Services;
using Dezrez.Rezi.DataContracts.Events.Query;

namespace Dezrez.Rezi.Training.Controllers
{
    public class EventController : BaseApiController
    {
        private readonly IEventDomainService _eventDomainService;

        public EventController(IEventDomainService eventDomainService)
        {
            _eventDomainService = eventDomainService;
        }

        // GET api/event
        public IEnumerable<EventDataContract> Get()
        {
            var events = _eventDomainService.GetEvents();

            return events;
        }

        // POST api/event
        public IHttpActionResult Post([FromBody]EventDataContract e)
        {
            _eventDomainService.AddEvent(e); 

            return Ok();
        }
    }
}