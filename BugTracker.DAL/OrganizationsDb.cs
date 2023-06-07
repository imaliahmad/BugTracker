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
        Organizations GetById(int id);
        bool Insert(Organizations obj);
        bool Update(Organizations obj);
        bool Delete(int id);
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
        public Organizations GetById(int id)
        {
            var obj = context.Organizations.Find(id);
            return obj;
        }
        public bool Insert(Organizations obj)
        {
            context.Organizations.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(Organizations obj)
        {
            context.Organizations.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.Organizations.Find(id);
            context.Organizations.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
