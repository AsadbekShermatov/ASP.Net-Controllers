using ASP.Net_Controllers.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<StudentContext>(contex =>
{
    contex.UseSqlServer(connectionString);  
});
var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
