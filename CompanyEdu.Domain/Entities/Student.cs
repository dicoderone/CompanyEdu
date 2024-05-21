namespace CompanyEdu.Domain.Entities
{
    public class Student
    {
        public Student()
        {
            Attendances = new HashSet<Attendance>();

            StudentInGroups = new HashSet<StudentInGroup>();
        }

        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime BirtDate { get; set; }

        public DateTime CreateDateTime { get; set; }

        public string PhoneNumber { get; set; }


        public ICollection<Attendance> Attendances { get; set; }

        public ICollection<StudentInGroup> StudentInGroups { get; set; }
    }
}
