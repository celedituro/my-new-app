using System.Data.Common;
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

        public async void UpdatePeople(IEnumerable<Person> people)
        {
            AgeCalculator calculator = new AgeCalculator();
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);
            for(int idx = 0; idx < people.Count(); idx++)
            {
                var person = people.ElementAt(idx);;
                Category category = factory.CreateCategory(person.DateOfBirth);
                person.TransitionTo(category);
               await  _repository.Update(person);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            var data = await _repository.GetAll();
            if (data is null)
            {
                return NotFound();
            };

            this.UpdatePeople(data);
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

        public void SetCategoryTo(Person person)
        {
            AgeCalculator calculator = new AgeCalculator();
            CategoryMapper mapper = new CategoryMapper(calculator);
            CategoryFactory factory = new CategoryFactory(mapper);
            Category category = factory.CreateCategory(person.DateOfBirth);
            person.TransitionTo(category);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {   
            if (person is null)
            {
                return NotFound();
            }

            this.SetCategoryTo(person);
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