namespace Assignments.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Manger { get; set; }

        public List<Instractor> Insts { get; set; }

        public List<Trainee> Trainees { get; set; }

        public List<Course> Courses { get; set; }
    }
}
