﻿using ContosoUniversityWebApp.Shared.DTOs;

namespace ContosoUniversityWebApp.Web.Services.Students;
public interface IStudentService
{
	Task GetStudents();

	Task<StudentDetailDTO> GetStudent(int Id);

    Task CreateStudent(CreateStudentDTO student);

    Task UpdateStudent(CreateStudentDTO student, int id);
	Task DeleteStudent(int id);
}
