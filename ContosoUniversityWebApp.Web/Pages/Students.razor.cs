namespace ContosoUniversityWebApp.Web.Pages;
public partial class Students
{

	protected override async Task OnInitializedAsync()
	{
		await studentService.GetStudents();
	}
}
