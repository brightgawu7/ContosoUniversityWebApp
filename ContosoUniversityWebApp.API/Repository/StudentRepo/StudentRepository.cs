using ContosoUniversityWebApp.API.Data;
using ContosoUniversityWebApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityWebApp.API.Repository.StudentRepo;
public class StudentRepository : IStudentRepository
{

	private readonly SchoolContext _context;

	public StudentRepository(SchoolContext context)
	{
		_context = context;
	}

	public async Task<Student> GetStudent(int id)
	{
		var student = await _context.Students
			.Include(s => s.Enrollments)
				.ThenInclude(e => e.Course)
			.AsNoTracking()
			.FirstOrDefaultAsync(m => m.ID == id);

		return student;
	}

	public async Task<IEnumerable<Student>> GetStudents()
	{

		return await _context.Students.ToListAsync();
	}
}
