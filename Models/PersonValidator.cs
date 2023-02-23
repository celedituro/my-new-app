using FluentValidation;

namespace my_new_app.Models
{
    public class PersonValidator : AbstractValidator<Person>  
    {
        public PersonValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Please, set a value for {PropertyName}")
                .Length(3, 30).WithMessage("Please, set a value with more than 3 and less than 30 letters for {PropertyName}")
                .Must(BeAValidName).WithMessage("Please, set a valid value with no numbers for {PropertyName}");

            RuleFor(person => person.DateOfBirth)
                .Must(BeBeforeThanToday)
                .WithMessage("Please, set a valid value that is not a future date for {PropertyName}");
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