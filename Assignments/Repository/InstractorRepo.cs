using Assignments.Models;

namespace Assignments.Repository
{
    public class InstractorRepo:IRepository<Instractor>
    {
        ITIContext context;
        public InstractorRepo(ITIContext _context)
        {
            context = _context;
        }
        public void Add(Instractor instractor)
        {
            context.Add(instractor);
        }
        public void Update(Instractor instractor)
        {
            context.Update(instractor);

        }

        public void Delete(int id)
        {
            Instractor Emp = GetByID(id);
            context.Remove(Emp);
        }
        public List<Instractor> GetAll()
        {
            return context.Instractor.ToList();
        }
        public Instractor GetByID(int id)
        {
            return context.Instractor.FirstOrDefault(e => e.Id == id);
        }

        
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
