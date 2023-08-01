﻿using ContosoUniversityWebApp.Shared.Models;

namespace ContosoUniversityWebApp.Shared.DTOs;
public class StudentDTO
{
	public int ID { get; set; }
	public string? LastName { get; set; }
	public string? FirstMidName { get; set; }
	public DateTime EnrollmentDate { get; set; }

}
