using ContosoUniversityWebApp.Shared.DTOs;

namespace ContosoUniversityWebApp.Web.Store;
public class StudentState:IStudentState
{
	public IEnumerable<StudentDTO>? Students { get; set; }
}
