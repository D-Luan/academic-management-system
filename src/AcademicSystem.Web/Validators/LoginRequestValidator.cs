using FluentValidation;
using AcademicSystem.Web.DTOs;

namespace AcademicSystem.Web.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("The email format is invalid.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}