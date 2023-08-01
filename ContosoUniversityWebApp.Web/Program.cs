using ContosoUniversityWebApp.Web;
using ContosoUniversityWebApp.Web.Services;
using ContosoUniversityWebApp.Web.Services.Students;
using ContosoUniversityWebApp.Web.Store;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7195") });

builder.Services.AddScoped<IStudentState, StudentState>();

builder.Services.AddScoped<IStudentService, StudentService>();

await builder.Build().RunAsync();
