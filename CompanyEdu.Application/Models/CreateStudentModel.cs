using System.ComponentModel.DataAnnotations;

namespace CompanyEdu.Application.Models
{
    public class CreateStudentModel
    {
        [Required]
        public string? FullName { get; set; }

        public DateTime BirtDate { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }
    }
}
