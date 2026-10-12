using System.Security;

namespace NZWalksWebAPI.Dtos.Student
{
    public class UpdateStudentRequestDto
    {

        public string StudentName { get; set; }

        public string? StudentEmail { get; set; }

        public string? StudentPhone { get; set; }
    }
}
