using Assignments.Models;

namespace Assignments.Repository
{
    public class DepartmentRepo:IRepository<Department>
    {

        ITIContext context;
        public DepartmentRepo(ITIContext _context)
        {
            context = _context;
        }
        public void Add(Department department)
        {
            context.Add(department);
        }
        public void Update(Department department)
        {
            context.Update(department);

        }

        public void Delete(int id)
        {
            Department Emp = GetByID(id);
            context.Remove(Emp);
        }
        public List<Department> GetAll()
        {
            return context.Department.ToList();
        }
        public Department GetByID(int id)
        {
            return context.Department.FirstOrDefault(e => e.Id == id);
        }
       
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
