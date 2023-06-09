using BugTracker.BOL;
using BugTracker.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    public interface IOrganizationsDb
    {
        IEnumerable<Organizations> GetAll();
        Organizations GetById(Guid id);
        Organizations Insert(Organizations obj);
        Organizations Update(Organizations obj);
        bool Delete(Guid id);
    }
    public class OrganizationsDb : IOrganizationsDb
    {
        private AppDbContext context;
        public OrganizationsDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Organizations> GetAll()
        {
            return context.Organizations.ToList();
        }
        public Organizations GetById(Guid id)
        {
            var obj = context.Organizations.Find(id);
            return obj;
        }
        public Organizations Insert(Organizations obj)
        {
            context.Organizations.Add(obj);
            context.SaveChanges();
            return obj;
        }
        public Organizations Update(Organizations obj)
        {
            context.Organizations.Update(obj);
            context.SaveChanges();
            return obj;
        }
        public bool Delete(Guid id)
        {
            var obj = context.Organizations.Find(id);
            context.Organizations.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
