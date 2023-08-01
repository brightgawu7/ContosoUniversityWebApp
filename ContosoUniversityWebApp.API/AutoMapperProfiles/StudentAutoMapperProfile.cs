using AutoMapper;
using ContosoUniversityWebApp.Shared.DTOs;
using ContosoUniversityWebApp.Shared.Models;

namespace ContosoUniversityWebApp.API.AutoMapperProfiles;
public class StudentAutoMapperProfile : Profile
{
	public StudentAutoMapperProfile()
	{
		CreateMap<Student, StudentDTO>();
	}
}
