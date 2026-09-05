namespace NZWalksWebAPI.Models.School
{
    public class Student
    {
        public Guid StudentID { get; set; }
        public string StudentName { get; set; }

        public string? StudentEmail { get; set; }

        public string? StudentPhone { get; set; }
    }
}
