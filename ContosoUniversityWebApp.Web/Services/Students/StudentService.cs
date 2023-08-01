using System.Net.Http.Json;
using ContosoUniversityWebApp.Shared.DTOs;
using ContosoUniversityWebApp.Web.Store;

namespace ContosoUniversityWebApp.Web.Services.Students;
public class StudentService : IStudentService
{
	private readonly HttpClient _http;

	private readonly IStudentState _studentState;



	public StudentService(HttpClient http, IStudentState studentState)
	{
		_http = http;
		_studentState = studentState;
	}


	public async Task GetStudents()
	{
		var result = await _http.GetFromJsonAsync<IEnumerable<StudentDTO>>("api/students");
		if (result != null)
			_studentState.Students = result;
	}


	public async Task<StudentDetailDTO> GetStudent(int Id)
	{
		var result = await _http.GetFromJsonAsync<StudentDetailDTO>($"api/students/{Id}");
		if (result != null)
			return result;
		throw new Exception("Hero not found!");
	}

}
