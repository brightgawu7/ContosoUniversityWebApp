using ContosoUniversityWebApp.Shared.DTOs;
using ContosoUniversityWebApp.Shared.Models;

namespace ContosoUniversityWebApp.API.Repository.StudentRepo;
public interface IStudentRepository
{
	Task<IEnumerable<Student>> GetStudents();
	Task<Student> GetStudent(int id);
	
	Task CreateStudent(CreateStudentDTO data);

	Task<bool> UpdateStudent(int id, CreateStudentDTO data);

	Task<bool> DeleteSudent(int id);
}
