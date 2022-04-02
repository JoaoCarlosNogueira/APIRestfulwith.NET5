using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5.Model;
using RestWithASPNET5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> logger;
        private IpersonService personService;

        public PersonController(ILogger<PersonController> _logger, IpersonService _ipersonService)
        {
            logger = _logger;
            personService = _ipersonService;
        }

        [HttpGet()]
        public IActionResult Get()
        {

            return Ok(personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = personService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);

        }

        [HttpPost()]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(personService.Create(person));

        }

        [HttpPut()]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(personService.Update(person));


        } 
        [HttpDelete()]
        public IActionResult Delete(long id)
        {
             personService.Delete(id);
             return NoContent();

        }

    }
}

