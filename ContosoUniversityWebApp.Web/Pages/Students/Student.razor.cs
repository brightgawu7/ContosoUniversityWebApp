using ContosoUniversityWebApp.Shared.DTOs;

namespace ContosoUniversityWebApp.Web.Pages.Students;
public partial class Student
{
    StudentDetailDTO? student;
    protected override async Task OnInitializedAsync()
    {
        student = await studentService.GetStudent(Id);
    }
}
