using System.ComponentModel.DataAnnotations.Schema;

namespace Assignments.Models
{
    public class Trainee
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Imag { get; set; }

        public string Address {  get; set; }
        public int Grade {  get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public Department Department { get; set; }

        public List<CrsResult> CrsResults { get; set; }

    }
}
