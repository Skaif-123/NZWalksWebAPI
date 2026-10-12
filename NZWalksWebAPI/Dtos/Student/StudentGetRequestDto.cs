using System.ComponentModel.DataAnnotations;

namespace NZWalksWebAPI.Dtos.Student
{
    public class StudentGetRequestDto
    {
        [Key]
        public Guid StudentID { get; set; }
        public string StudentName { get; set; }
    }
}
