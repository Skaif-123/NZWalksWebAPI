using Microsoft.EntityFrameworkCore;
using NZWalksWebAPI.Data;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();



builder.Services.AddDbContext<NZWalksDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalks"));
});


// Add the SchoolCoursesDBContext to the service container
// This allows the application to use the SchoolCoursesDBContext for database operations related to school courses.
//We are basically adding or passing connection string to the SchoolCoursesDBContext 
//whenever This context is called we can use the connection string to connect to the database and perform operations.

builder.Services.AddDbContext<SchoolCoursesDBContext>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolCourse"));
});



var app = builder.Build();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
