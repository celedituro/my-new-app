using FluentValidation;

namespace my_new_app.Models
{
    public class PersonValidator : AbstractValidator<Person>  
    {
        public PersonValidator()
        {
            RuleFor(person => person.DateOfBirth)
                .Must(BeBeforeThanToday)
                .WithMessage("Por favor, ingrese una fecha anterior o igual a la de hoy como fecha de nacimiento");
        }

        private bool BeBeforeThanToday(DateOnly birthDate)
        {
            var today= DateTime.Now;
            var birth = birthDate.ToDateTime(TimeOnly.MinValue);
            return today.CompareTo(birth) > 0;
        }
    }
}