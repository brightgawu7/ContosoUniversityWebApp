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
	public StudentsController(IMapper mapper, IStudentRepository studentRepository)
	{
		_mapper = mapper;
		_studentRepository = studentRepository;
	}


	[HttpGet]
	public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
	{
		var allStudents = await _studentRepository.GetStudents();

		var students = _mapper.Map<IEnumerable<StudentDTO>>(allStudents);
		return Ok(students);
	}
}
