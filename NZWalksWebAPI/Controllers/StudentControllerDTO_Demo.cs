using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksWebAPI.Data;
using NZWalksWebAPI.Dtos.Student;
using NZWalksWebAPI.Models.School;

namespace NZWalksWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentControllerDTO_Demo : ControllerBase
    {
        private readonly SchoolCoursesDBContext _schoolContext;
        public StudentControllerDTO_Demo(SchoolCoursesDBContext schoolCoursesDBContext)
        {
                _schoolContext = schoolCoursesDBContext;
        }


        //Get Method usage demo shown
        [HttpGet]
        public IActionResult GetAll()
        {
            //Fetching data from Student table all data
            var StudentDomain=_schoolContext.Students.ToList();

            //mapping data from Domain Model to DTOs created
            //created List that accepts only the DTOs type object 
            var studentDTO = new List<StudentGetRequestDto>();

            foreach (var singleStudentRecord in StudentDomain) {

                studentDTO.Add(
                new StudentGetRequestDto
                {
                    StudentID = singleStudentRecord.StudentID,
                    StudentName = singleStudentRecord.StudentName
                });  
            }

            return Ok(studentDTO);
        }


        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id) {

            var StudentDomainByID = _schoolContext.Students.FirstOrDefault(x => x.StudentID == id);

            if (StudentDomainByID == null)
            {
                return NotFound();
            }

            var studentDTO=new StudentGetRequestDto
            {
               StudentID=StudentDomainByID.StudentID,
               StudentName=StudentDomainByID.StudentName
            };


            return Ok(studentDTO);

        }



        [HttpPost]
        public IActionResult Create([FromBody]StudentPostRequestDto DTO)  {

            var StudentModel = new Student
            {
                StudentName = DTO.StudentName,
                StudentEmail = DTO.StudentEmail,
                StudentPhone = DTO.StudentPhone

            };

            _schoolContext.Students.Add(StudentModel);
            _schoolContext.SaveChanges();

            //mapping again to RequestDTO
            var getStudentDetails = new StudentGetRequestDto
            {
                StudentID=StudentModel.StudentID,
                StudentName=StudentModel.StudentName
            };


            return CreatedAtAction(nameof(GetById),new {Id=getStudentDetails.StudentID},getStudentDetails);
        }


        [HttpPut("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody]  UpdateStudentRequestDto DTO) {

            var StudentDomain = _schoolContext.Students.FirstOrDefault(x => x.StudentID == id);

            if (StudentDomain == null)
            {
                return NotFound();
            }


            //Changing the data of the Domain model with the data received from the DTO
            StudentDomain.StudentName = DTO.StudentName;
            StudentDomain.StudentEmail = DTO.StudentEmail;
            StudentDomain.StudentPhone = DTO.StudentPhone;

            //mapping to request DTO again
            var studentDto=new StudentGetRequestDto
            {
                StudentID = StudentDomain.StudentID,
                StudentName = StudentDomain.StudentName
            };

            return Ok(studentDto);
        }


        [HttpDelete("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {

            var StudentDomain = _schoolContext.Students.FirstOrDefault(x => x.StudentID == id);

            if (StudentDomain == null)
            {
                return NotFound();
            }

            _schoolContext.Students.Remove(StudentDomain);
            _schoolContext.SaveChanges();

            return Ok("Deleted the record");

        }
   
    }
}
