using Microsoft.EntityFrameworkCore;
using NZWalksWebAPI.Models.School;

namespace NZWalksWebAPI.Data
{

    //Don't forget to extend from DbContext Class.
    // we will get an error if we don't extend from DbContext class.
    public class SchoolCoursesDBContext:DbContext
    {
        /*
         This is the constructor of the SchoolCoursesDBContext class. It takes a DbContextOptions<SchoolCoursesDBContext> object as a parameter and passes it to the base class constructor. 
         It has options as parameter, we get parameter from appsettingsg.json file.
         we get connection string ,Db Provider and other options from appsettings.json file.
        we get it inside options ; then we pass it to the base (options).
        basically base class is refering to DbCOntext which we are inheriting from. 
        so this configuration information is going to be passed to Dbcontext class; 
        which will use it to configure the database connection and other options for the context.
         
         */
        public SchoolCoursesDBContext(DbContextOptions<SchoolCoursesDBContext> options) : base(options)
        {
                
        }


        //defining all the models which we have created
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
