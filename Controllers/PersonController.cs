using Microsoft.AspNetCore.Mvc;
using my_new_app.DataAccess.Interfaces;
using my_new_app.Models;

namespace my_new_app.Controllers
{
    [ApiController]
    [Route("person")]
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
        public async Task<ActionResult<Person>> GetPerson(string id)
        {   
            if (id is null)
            {
                return NotFound();
            }
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
            return CreatedAtAction("/person", new { id = person.Id });
        }

        [HttpGet("name={name}")]
        public ActionResult<Person> GetPersonByName(string name)
        {
            if (name is null)
            {
                return NotFound();
            }
            var person = _repository.GetByName(name);

            if (person is null)
            {
                return NotFound();
            }
            return Ok(person);
        }
    }
}