namespace NZWalksWebAPI.Models.School
{
    public class Enrollment
    {
        public Guid EnrollmentId { get; set; }// Primary key for the Enrollment table

        public Guid StudentId { get; set; } // Foreign key to the Student table

        public Guid CourseId { get; set; }// Foreign key to the Course table

        public decimal? Marks { get; set; }



        // Navigation properties
        //asp.net core automatically the studentID and courseID to the student and course table 
        //Good learning point: The navigation properties are used to establish relationships between entities in Entity Framework. In this case, the Enrollment class has navigation properties for the Student and Course classes, which allows you to easily access related data.
        public Student Student { get; set; }

        public Courses Course { get; set; }
    }
}
