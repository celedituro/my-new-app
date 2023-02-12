using Microsoft.AspNetCore.Mvc;
using my_new_app.DataAccess.Interfaces;
using my_new_app.Models;

namespace my_new_app.Controllers
{
    [ApiController]
    [Route("person")]
    public class PersonController : ControllerBase
    {
        private readonly IRepositoryAsync<Person> _repository;

        public PersonController(IRepositoryAsync<Person> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            var data = await _repository.GetAll();
            return Ok(data);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(string id)
        {
            var person = await _repository.GetById(id);
            return person;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {   
            await _repository.Insert(person);
            return CreatedAtAction("/person", new { id = person.Id });
        }
    }
}