using Assignments.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignments.ModelView
{
    public class CourseDetailsViewModel
    {
        public int Id { get; set; }

        [unique]
        [MinLength(2, ErrorMessage = "Name Must be greater than 2 char")]
        public string Name { get; set; }
        [Range(50, 100, ErrorMessage = "Degree must be in range 50 to 100")]
        public int Degree { get; set; }

        [Remote("CheckDegree", "Course", AdditionalFields = "Degree", ErrorMessage = "mindegree must be less than degree")]
        public int MinDegree { get; set; }

        [Remote("CheckHours", "Course", AdditionalFields = "Hours", ErrorMessage = "Hours not able multible 3")]
        public int Hours { get; set; }

        public int DepartmentID { get; set; }

        public Department ?Department { get; set; }
        public List<Department>? Departments { get; set; }
        public List<Instractor>? Insts { get; set; }

      public List<CrsResult>? CrsResults { get; set; }
    }
}
