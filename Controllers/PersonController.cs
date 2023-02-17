using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using my_new_app.DataAccess.Interfaces;
using my_new_app.Models;

namespace my_new_app.Controllers
{
    [ApiController]
    [Route("people")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            var data = await _repository.GetAll();

            if (data is null)
            {
                return NotFound();
            };
            return Ok(data);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {   
            var person = await _repository.GetById(id);

            if (person is null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {   
            if (person is null)
            {
                return NotFound();
            }

            await _repository.Insert(person);
            return CreatedAtAction("/people", new { id = person.Id });
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Person>> Index(string word)
        {
            if (word is null)
            {
                return NotFound();
            }
            var people = _repository.FilterByNameOrCategory(word);

            if (people is null)
            {
                return NotFound();
            }
            return Ok(people);
        }
    }
}