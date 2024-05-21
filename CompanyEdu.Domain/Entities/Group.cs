namespace CompanyEdu.Domain.Entities
{
    public class Group
    {
        public Group()
        {
            Lessons = new HashSet<Lesson>();

            GroupStudents = new HashSet<StudentInGroup>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TeacherId { get; set; }


        public User Teacher { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

        public ICollection<StudentInGroup> GroupStudents { get; set; }
    }
}
