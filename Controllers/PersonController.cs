using Microsoft.AspNetCore.Mvc;
using my_new_app.DataAccess.Interfaces;
using my_new_app.Models;
using my_new_app.Services.Interfaces;

namespace my_new_app.Controllers
{
    [ApiController]
    [Route("people")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;
        private readonly IAgeCalculator _calculator;
        private readonly ICategoryMapper _mapper;
        private readonly ICategoryFactory _factory;

        public PersonController(IPersonRepository repository, IAgeCalculator calculator, ICategoryMapper mapper, ICategoryFactory factory)
        {
            _repository = repository;
            _calculator = calculator;
            _mapper = mapper;
            _factory = factory;
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateCategoryOF(IEnumerable<Person> people)
        {
            for(int idx = 0; idx < people.Count(); idx++)
            {
                var person = people.ElementAt(idx);;
                Category category = this._factory.CreateCategory(person.DateOfBirth);
                if(category.Name != person.CategoryName)
                {   
                    person.GetOlder();
                    await  _repository.Update(person);
                }
            }
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            var data = await _repository.GetAll();
            if (data is null)
            {
                return NotFound();
            };

            await this.UpdateCategoryOF(data);
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

            Category category = this._factory.CreateCategory(person.DateOfBirth);
            person.TransitionTo(category);              
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