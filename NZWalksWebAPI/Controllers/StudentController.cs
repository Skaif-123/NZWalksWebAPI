using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksWebAPI.Data;
using NZWalksWebAPI.Models.School;

namespace NZWalksWebAPI.Controllers
{
    //below is use for specifing the route 
    [Route("api/[controller]")]


    /*
     * This [ApiController] has many advantages like automatic model validation, 
     * means incoming request will be automatically validated based on the model attributes and if any validation fails, 
     * it will return a 400 Bad Request response with the validation errors.
     * plus we can use many other features like [From Route],[From Body],[From Form] etc.
     *Many reurn methods we get like Ok(),NotFound(),BadRequest() etc. which we can use to return the response.
     */
    [ApiController]
    public class StudentController : ControllerBase
    {
        //declaring tthe object of DBContext Class
        //we are using readonly to make object as immutable,
        //we don't want anyone to change the value of dbContext object after it is initialized in the constructor.
        // i.e we use reaonly in many places in asp.net core
        //it also tells  devlopers that these all object or variables should not be changes in the code 
        //readonly is a class level field declaration
        private readonly SchoolCoursesDBContext dbContext;


        //first we will create a Constructor;
        //passing dbContext as parameter to constructor then we will assign it to the private field dbContext

        public StudentController( SchoolCoursesDBContext dbContext)
        {
                this.dbContext = dbContext;
        }




        //Creating the get method
        [HttpGet]

        //we have add Students List
        //So visuallize like this Students=[{},{},{}]; similar way we store information
        //syntax is var List=new List<ClassNameModel>()
        //List.Add(new ClassNameModel{Property1=Value1,Property2=Value2});
        //Thing like List.Add({});; next List.add({});; next List.add({});; and so on we can add the information in the list

        public IActionResult GetAll() {

            var Students = dbContext.Students.ToList();

            return Ok(Students);
        }




        //Writing method GetById; to fetch by ID
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute]Guid id)
        {
            //this is use to object base on Id
            //below find Method is only used when we have primary key with us
            //var Student = dbContext.Students.Find(id);

           

            //This below method we can use we any field of sql not neccessary primary field
            //As you can see x.[column name]==[value which we are passing]
            //Below is a better method and is recommended...........
            var Student = dbContext.Students.FirstOrDefault(x=>x.StudentID==id);

            if (Student == null)
            {
                //returns 404 code if not found
                return NotFound();
            }
            return Ok(Student);
        }

    }
}
