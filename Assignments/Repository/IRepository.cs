using Assignments.Models;

namespace Assignments.Repository
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T GetByID(int id);
        public void Add(T newObject);

        public void Update(T updatedObject);
        public void Delete(int id);

      
        
        public void Save();
    }
}
