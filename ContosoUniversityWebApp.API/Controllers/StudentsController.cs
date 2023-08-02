using AutoMapper;
using ContosoUniversityWebApp.API.Data;
using ContosoUniversityWebApp.API.Repository.StudentRepo;
using ContosoUniversityWebApp.Shared.DTOs;
using ContosoUniversityWebApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityWebApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{

	private readonly IStudentRepository _studentRepository;

	private readonly IMapper _mapper;

	private readonly SchoolContext _context;

	public StudentsController(IMapper mapper, IStudentRepository studentRepository, SchoolContext context)
	{
		_mapper = mapper;
		_studentRepository = studentRepository;
		_context = context;
	}


	[HttpGet]
	public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
	{
		var allStudents = await _studentRepository.GetStudents();

		var students = _mapper.Map<IEnumerable<StudentDTO>>(allStudents);
		return Ok(students);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Student>> GetStudent([FromRoute] int id)
	{
		if (id == 0)
		{
			return NotFound($"Invalid Student Id #{id}");
		}

		var student = await _studentRepository.GetStudent(id);

		if (student == null)
		{
			return NotFound($"Student of Id #{id} Does Not Exist");
		}

		return Ok(_mapper.Map<StudentDetailDTO>(student));
	}


	[HttpPost]
	public async Task<ActionResult> CreateStudent([FromBody] CreateStudentDTO data)
	{


		await _studentRepository.CreateStudent(data);

		return Ok("Student Created");
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<StudentDTO>> UpdateStudent([FromRoute] int id, [FromBody] CreateStudentDTO data)
	{

		bool studentUpdated = await _studentRepository.UpdateStudent(id, data);

		if (!studentUpdated)
			return NotFound("Sorry, but no hero for you. :/");
		
		return Ok();
	}


	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteStudent(int id)
	{
	bool studentDeleted=await  _studentRepository.DeleteSudent(id);

		if (!studentDeleted)
			return NotFound("Sorry, but no hero for you. :/");

	
		return Ok("User Deleted");
	}
}
