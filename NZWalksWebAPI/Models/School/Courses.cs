namespace NZWalksWebAPI.Models.School
{
    public class Courses
    {
        public Guid CourseId { get; set; }

        public string CourseName { get; set; }

        public  string? CourseDescription { get; set; }

        public string TeacherName { get; set; }
    }
}
