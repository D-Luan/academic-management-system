using FluentValidation;
using AcademicSystem.Web.DTOs;

namespace AcademicSystem.Web.Validators;

public class RegisterStudentValidator : AbstractValidator<RegisterStudentRequest>
{
    public RegisterStudentValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("The email format is invalid.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6).WithMessage("The password must be at least 6 characters long.");

        RuleFor(x => x.FullName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.RegistrationNumber)
            .NotEmpty()
            .MaximumLength(10)
            .Matches(@"^[0-9]+$").WithMessage("Register Number must be contain only numbers.");

        RuleFor(x => x.ZipCode)
            .NotEmpty()
            .Matches(@"^\d{5}-?\d{3}$").WithMessage("Zip Code is invalid.");
    }
}
