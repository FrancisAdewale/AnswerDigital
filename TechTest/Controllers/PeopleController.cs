using System;
using Microsoft.AspNetCore.Mvc;
using TechTest.Repositories;
using TechTest.Repositories.Models;

namespace TechTest.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public PeopleController(IPersonRepository personRepository)
        {
            this.PersonRepository = personRepository;
        }

        private IPersonRepository PersonRepository { get; }

        [HttpGet]
        public IActionResult GetAll()
        {
            // TODO: Step 1
            //
            // Implement a JSON endpoint that returns the full list
            // of people from the PeopleRepository. If there are zero
            // people returned from PeopleRepository then an empty
            // JSON array should be returned.

            var personList = PersonRepository.GetAll();

            if (personList == null)
            {
                return Ok();
            } 
 
            return Ok(personList);

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var personObj = PersonRepository.Get(id);
            // TODO: Step 2
            //
            // Implement a JSON endpoint that returns a single person
            // from the PeopleRepository based on the id parameter.
            // If null is returned from the PeopleRepository with
            // the supplied id then a NotFound should be returned.

            if(personObj == null)
            {
                return NotFound(personObj);
            }

            return Ok(personObj);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PersonUpdate personUpdate)
        {
            // TODO: Step 3
            //
            // Implement an endpoint that receives a JSON object to
            // update a person using the PeopleRepository based on
            // the id parameter. Once the person has been successfully
            // updated, the person should be returned from the endpoint.
            // If null is returned from the PeopleRepository then a
            // NotFound should be returned.

            var personID = PersonRepository.Get(id);

            if(personID == null) 
            {
                return NotFound(personID);
            }

            personID.Authorised = personUpdate.Authorised;
            personID.Enabled = personUpdate.Enabled;
            personID.Colours = personUpdate.Colours;

            PersonRepository.Update(personID);

            return Ok(personID);

        }
    }
}