using FluentValidation;

namespace DemoAPI.Validators;

public class PersonValidator : AbstractValidator<PersonModel>
{
    public PersonValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required!")
            .Length(2, 50).WithMessage("Length of first name is invalid")
            .Must(BeAValidName).WithMessage("Name cannot contain invalid characters");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required!")
            .Length(2, 50).WithMessage("Length of first name is invalid")
            .Must(BeAValidName).WithMessage("Name cannot contain invalid characters");
    }

    protected bool BeAValidName(string name)
    {
        name = name.Replace(" ", "");
        name = name.Replace("-", "");
        return name.All(Char.IsLetter);
    }
}
