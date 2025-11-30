using FluentValidation;
using AcademicSystem.Web.DTOs;

namespace AcademicSystem.Web.Validators;

public class CreateCourseValidator : AbstractValidator<CreateCourseRequest>
{
    public CreateCourseValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.TotalHours)
            .GreaterThan(0);

        RuleFor(x => x.Type)
            .InclusiveBetween(1, 2)
            .WithMessage("Invalid Course Type. 1 = Bachelor, 2 = Technologist.");
    }
}