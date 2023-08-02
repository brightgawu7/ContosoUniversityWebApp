using AutoMapper;
using ContosoUniversityWebApp.API.Data;
using ContosoUniversityWebApp.Shared.DTOs;
using ContosoUniversityWebApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContosoUniversityWebApp.API.Repository.StudentRepo;
public class StudentRepository : IStudentRepository
{

	private readonly SchoolContext _context; 
	private readonly IMapper _mapper;

	public StudentRepository(SchoolContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	public async Task CreateStudent(CreateStudentDTO data)
	{
		var student = _mapper.Map<Student>(data);

		_context.Add(student);

		await _context.SaveChangesAsync();
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

	public async Task<bool> UpdateStudent(int id, CreateStudentDTO data)
	{
		var student = await _context.Students
						.FirstOrDefaultAsync(s => s.ID == id);

		if (student == null)
			return false;

		_mapper.Map<CreateStudentDTO, Student>(data, student);

		await _context.SaveChangesAsync();

		return true;
	}

	public async Task<bool> DeleteSudent(int id)
	{
		var student = await _context.Students
	   .FirstOrDefaultAsync(sh => sh.ID == id);


		if (student == null)
			return false;

		_context.Students.Remove(student);
		await _context.SaveChangesAsync();

		return true;
	}

}
