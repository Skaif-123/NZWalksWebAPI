using System.ComponentModel.DataAnnotations;

namespace NZWalksWebAPI.Models.School
{
    public class Courses
    {
        [Key]
        public Guid CourseId { get; set; }

        public string CourseName { get; set; }

        public  string? CourseDescription { get; set; }

        public string TeacherName { get; set; }
    }
}
