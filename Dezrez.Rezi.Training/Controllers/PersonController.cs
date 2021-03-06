﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using Dezrez.Rezi.Abstractions.Services;
using Dezrez.Rezi.DataContracts.People.Query;

namespace Dezrez.Rezi.Training.Controllers
{
    public class PersonController : BaseApiController
    {
        private readonly IPersonDomainService _personDomainService;

        public PersonController(IPersonDomainService personDomainService)
        {
            _personDomainService = personDomainService;
        }

        // GET api/person
        public IEnumerable<PersonDataContract> Get()
        {
            var people = _personDomainService.GetPeople();

            return people;
        }

        // POST api/person
        public IHttpActionResult Post([FromUri]string name)
        {
            _personDomainService.AddPerson(name);

            return Ok();
        }
    }
}
