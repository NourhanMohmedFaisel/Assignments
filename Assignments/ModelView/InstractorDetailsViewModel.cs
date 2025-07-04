using Assignments.Models;

namespace Assignments.ModelView
{
    public class InstractorDetailsViewModel
    {
        public int ID { get; set; }
        public int Salary { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public IFormFile Imag { get; set; }
        public string Address { get; set; }
        public int DepartmentID { get; set; }
        public int CourseID { get; set; }

        public List<Course> Courses { get; set; }
        public List<Department> Departments { get; set; }

    }
}
