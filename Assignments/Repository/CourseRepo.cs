using Assignments.Models;

namespace Assignments.Repository
{
    public class CourseRepo:IRepository<Course> ,ICourseRepo
    {
        ITIContext context;
        public CourseRepo(ITIContext _context)
        {
            context = _context;
        }
        public void Add(Course course)
        {
            context.Add(course);
        }
        public void Update(Course course)
        {
            context.Update(course);

        }

        public void Delete(int id)
        {
           Course Emp = GetByID(id);
            context.Remove(Emp);
        }
        public List<Course> GetAll()
        {
            return context.Course.ToList();
        }
        public Course GetByID(int id)
        {
            return context.Course.FirstOrDefault(e => e.Id == id);
        }

        public  List<Course> GetCoursesByDepartmentID(int deptID)
        {
            return context.Course.Where(i => i.DepartmentID == deptID).ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
