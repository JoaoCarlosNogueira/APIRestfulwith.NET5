using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5.Model;
using RestWithASPNET5.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Hypermedia.Filters;

namespace RestWithASPNET5.Controllers
{   [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> logger;
        private IpersonBusiness personService;

        public PersonController(ILogger<PersonController> _logger, IpersonBusiness _ipersonBusinees)
        {
            logger = _logger;
            personService = _ipersonBusinees;
        }

        [HttpGet()]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {

            return Ok(personService.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(personService.Create(person));

        }

        [HttpPut()]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
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

