using ContosoUniversityWebApp.Shared.DTOs;

namespace ContosoUniversityWebApp.Web.Store;
public interface IStudentState
{
	IEnumerable<StudentDTO>? Students { get; set; }
}
