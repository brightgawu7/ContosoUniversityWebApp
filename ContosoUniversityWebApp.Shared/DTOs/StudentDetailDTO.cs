using ContosoUniversityWebApp.Shared.Models;

namespace ContosoUniversityWebApp.Shared.DTOs;
public class StudentDetailDTO
{
	public int ID { get; set; }
	public string? LastName { get; set; }
	public string? FirstMidName { get; set; }
	public DateTime EnrollmentDate { get; set; }

	public ICollection<EnrollmentDTO>? Enrollments { get; set; }
}
