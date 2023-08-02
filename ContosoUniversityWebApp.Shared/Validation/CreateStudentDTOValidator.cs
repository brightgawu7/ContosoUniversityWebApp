using ContosoUniversityWebApp.Shared.DTOs;
using FluentValidation;

namespace ContosoUniversityWebApp.Shared.Validation;

public class CreateStudentDTOValidator:AbstractValidator<CreateStudentDTO>
{
    public CreateStudentDTOValidator()
    {
		RuleFor(student => student.LastName).NotEmpty().WithMessage("Last Name is required");
		RuleFor(student => student.FirstMidName).NotEmpty().WithMessage("First Name is required");
		RuleFor(student => student.EnrollmentDate).NotEmpty().WithMessage("Enrollment Date is required");
	}
}
