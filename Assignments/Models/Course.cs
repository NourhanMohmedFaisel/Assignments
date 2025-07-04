using System.ComponentModel.DataAnnotations.Schema;

namespace Assignments.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree {  get; set; }

        public int MinDegree {  get; set; }
        public int Hours { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public Department Department { get; set; }

        public List<Instractor> Insts { get; set; }

        public List<CrsResult> CrsResults { get; set; }
    }
}
