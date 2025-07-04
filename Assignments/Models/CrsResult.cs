using System.ComponentModel.DataAnnotations.Schema;

namespace Assignments.Models
{
    public class CrsResult
    {
        public int Id {  get; set; }
        public int Degree { get; set;}
        [ForeignKey("Course")]
        public int CourseID { get; set; }

        public Course Course { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeID { get; set; }

        public Trainee Trainee { get; set; }
    }
}
