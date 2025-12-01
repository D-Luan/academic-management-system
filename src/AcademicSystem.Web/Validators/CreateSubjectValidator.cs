using FluentValidation;
using AcademicSystem.Web.DTOs;

namespace AcademicSystem.Web.Validators;

public class CreateSubjectValidator : AbstractValidator<CreateSubjectRequest>
{
    public CreateSubjectValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Subject name is required.")
            .MaximumLength(100).WithMessage("Subject name cannot exceed 100 characters.");

        RuleFor(x => x.Workload)
            .GreaterThan(0).WithMessage("Workload must be greater than zero.");
    }
}