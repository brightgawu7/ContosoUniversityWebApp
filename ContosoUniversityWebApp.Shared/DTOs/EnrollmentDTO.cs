using ContosoUniversityWebApp.Shared.Models;

namespace ContosoUniversityWebApp.Shared.DTOs;
public enum Grade
{
	A, B, C, D, F
}

public class EnrollmentDTO
{
	public int EnrollmentID { get; set; }
	public int CourseID { get; set; }
	public int StudentID { get; set; }
	public Grade? Grade { get; set; }

	public CourseDTO? Course { get; set; }
}
