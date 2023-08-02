namespace ContosoUniversityWebApp.Web.Pages.Students;
public partial class Students
{

    protected override async Task OnInitializedAsync()
    {
        await studentService.GetStudents();
    }
}
