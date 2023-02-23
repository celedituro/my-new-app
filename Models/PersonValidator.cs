using FluentValidation;

namespace my_new_app.Models
{
    public class PersonValidator : AbstractValidator<Person>  
    {
        public PersonValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Por favor, ingrese un nombre")
                .Length(3, 30).WithMessage("Por favor, ingrese un nombre con entre 3 y 30 letras");

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