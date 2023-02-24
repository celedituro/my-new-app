using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        private readonly ICategoryFactory _factory;
        public PersonController(IPersonRepository repository, ICategoryFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            var data = await _repository.GetAll();
            if (data is null)
            {
                return BadRequest();
            };
            
            // Update people category
            for(int idx = 0; idx < data.Count(); idx++)
            {
                var person = data.ElementAt(idx);;
                Category category = this._factory.CreateCategory(person.DateOfBirth);
                if(category.Name != person.CategoryName)
                {   
                    person.GetOlder();
                    await  _repository.Update(person);
                }
            }

            return Ok(data);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> PostPerson(Person person, IValidator<Person> validator)
        {   
            if (person is null)
            {
                return BadRequest();
            }

            ValidationResult result = validator.Validate(person);
            if (!result.IsValid)
            {
                var dictionary = new ModelStateDictionary();
                foreach (ValidationFailure failure in result.Errors)
                {
                    dictionary.AddModelError(
                        failure.PropertyName,
                        failure.ErrorMessage);
                }
                return ValidationProblem(dictionary);
            }

            // Set person's category
            Category category = this._factory.CreateCategory(person.DateOfBirth);
            person.TransitionTo(category);              
            await _repository.Insert(person);

            return CreatedAtAction("/people", new { id = person.Id });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Person>> Index(String word)
        {
            if (word is null)
            {
                return BadRequest();
            }

            var people = _repository.FilterByNameOrCategory(word);
            if (people is null)
            {
                return BadRequest();
            }

            return Ok(people);
        }
    }
}