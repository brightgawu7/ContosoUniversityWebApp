using ContosoUniversityWebApp.Shared.DTOs;
using FluentValidation;

namespace ContosoUniversityWebApp.Shared.Validation;

public class CreateStudentDTOValidator:AbstractValidator<CreateStudentDTO>
{
    public CreateStudentDTOValidator()
    {
		RuleFor(student => student.LastName).NotEmpty().WithMessage("LastName is required");
		RuleFor(student => student.FirstMidName).NotEmpty().WithMessage("FirstName is required");
		RuleFor(student => student.EnrollmentDate).NotEmpty().WithMessage("EnrollmentDate is required");
	}
}
