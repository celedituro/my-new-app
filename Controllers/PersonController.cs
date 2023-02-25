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

        /// <summary>
        /// Gets the list of all People
        /// </summary>
        /// <returns>A list of people</returns>
        /// <response code="200">Returns a list of all items</response>
        /// <response code="400">If the list of items is null</response>
           
        // GET: people/all
        [HttpGet("all")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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

        /// <summary>
        /// Creates a person
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST people
        ///     {        
        ///       "name": "Fulano",
        ///       "dateOfBirth": ""2000-02-24"",
        ///     }
        /// </remarks>
        /// <returns>A newly created person</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
           
        // GET: people
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Person>> PostPerson(Person person, IValidator<Person> validator)
        {   
            if (person is null)
            {
                return BadRequest();
            }

            // Show validation errors
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

        /// <summary>
        /// Gets a list of People that includes the word in his/her name o category name
        /// </summary>
        /// <returns>A list of people that meet the condition</returns>
        /// <response code="200">Returns a list of items</response>
        /// <response code="400">If the list of items is null</response>

        // GET: people?word="word"
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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