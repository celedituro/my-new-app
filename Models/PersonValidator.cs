using FluentValidation;

namespace my_new_app.Models
{
    public class PersonValidator : AbstractValidator<Person>  
    {
        public PersonValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Por favor, ingrese algún nombre")
                .Length(3, 30).WithMessage("Por favor, ingrese entre 3 y 30 letras para el nombre")
                .Must(BeAValidName).WithMessage("Por favor, no ingrese números para el nombre");

            RuleFor(person => person.DateOfBirth)
                .Must(BeBeforeThanToday)
                .WithMessage("Por favor, ingrese una fecha anterior o igual a la de hoy como fecha de nacimiento");
        }

        private bool BeAValidName(string name)
        {
            return name.All(Char.IsLetter);
        }

        private bool BeBeforeThanToday(DateOnly birthDate)
        {
            var today= DateTime.Now;
            var birth = birthDate.ToDateTime(TimeOnly.MinValue);
            return today.CompareTo(birth) > 0;
        }
    }
}