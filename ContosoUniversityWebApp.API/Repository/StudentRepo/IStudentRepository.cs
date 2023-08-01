using ContosoUniversityWebApp.Shared.Models;

namespace ContosoUniversityWebApp.API.Repository.StudentRepo;
public interface IStudentRepository
{
	Task<IEnumerable<Student>> GetStudents();
	Task<Student> GetStudent(int id);

}
