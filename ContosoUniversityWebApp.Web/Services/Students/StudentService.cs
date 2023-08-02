using System.Net.Http.Json;
using ContosoUniversityWebApp.Shared.DTOs;
using ContosoUniversityWebApp.Web.Store;
using Microsoft.AspNetCore.Components;

namespace ContosoUniversityWebApp.Web.Services.Students;
public class StudentService : IStudentService
{
	private readonly HttpClient _http;

	private readonly IStudentState _studentState;
	private readonly NavigationManager _navigationManager;


	public StudentService(HttpClient http, IStudentState studentState, NavigationManager navigationManager)
	{
		_http = http;
		_studentState = studentState;
		_navigationManager = navigationManager;
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

	public async Task CreateStudent(CreateStudentDTO student)
	{
		await _http.PostAsJsonAsync("api/students", student);
		_navigationManager.NavigateTo("/Students");
	}

	public async Task UpdateStudent(CreateStudentDTO student, int id)
	{
		await _http.PutAsJsonAsync($"api/students/{id}", student);
		_navigationManager.NavigateTo("/Students");

	}


	public async Task DeleteStudent(int id)
	{
		await _http.DeleteAsync($"api/students/{id}");
		_navigationManager.NavigateTo("/Students");

	}
}
