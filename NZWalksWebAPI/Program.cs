using Microsoft.EntityFrameworkCore;
using NZWalksWebAPI.Data;
using NZWalksWebAPI.Mappings;
using NZWalksWebAPI.Repository;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Register Swagger / OpenAPI generator services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<NZWalksDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalks"));
});

builder.Services.AddScoped<IVesselRepository, VesselRepository>();

// Add the SchoolCoursesDBContext to the service container
// This allows the application to use the SchoolCoursesDBContext for database operations related to school courses.
//We are basically adding or passing connection string to the SchoolCoursesDBContext 
//whenever This context is called we can use the connection string to connect to the database and perform operations.

builder.Services.AddDbContext<SchoolCoursesDBContext>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolCourse"));
});


builder.Services.AddDbContext<VesselDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VesselDB"));
});


    builder.Services.AddAutoMapper(cfg => { }, typeof(AutoMapperProfiles).Assembly); // Register AutoMapper and specify the assembly containing the mapping profiles)
        


var app = builder.Build();


// Configure the HTTP request pipeline to use Swagger in development (or globally)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // This renders the interactive Swagger UI web page
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
