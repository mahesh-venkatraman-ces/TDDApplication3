using TDDApplication3.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
DependencyInjection.RegisterBLLDependencies(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
namespace TDDApplication3.API
{
    public partial class Program { }
}
