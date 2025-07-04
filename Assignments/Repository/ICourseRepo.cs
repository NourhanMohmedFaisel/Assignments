using Assignments.Models;

namespace Assignments.Repository
{
    public interface ICourseRepo:IRepository<Course>
    {
        public List<Course> GetCoursesByDepartmentID(int deptID);
    }
}
