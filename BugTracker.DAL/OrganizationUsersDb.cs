using BugTracker.BOL;
using BugTracker.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    public interface IOrganizationUsersDb
    {
        IEnumerable<OrganizationUsers> GetAll();
        OrganizationUsers GetById(int id);
        bool Insert(OrganizationUsers obj);
        bool Update(OrganizationUsers obj);
        bool Delete(int id);
    }
    public class OrganizationUsersDb : IOrganizationUsersDb
    {
        private AppDbContext context;
        public OrganizationUsersDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<OrganizationUsers> GetAll()
        {
            return context.OrganizationUsers.ToList();
        }
        public OrganizationUsers GetById(int id)
        {
            var obj = context.OrganizationUsers.Find(id);
            return obj;
        }
        public bool Insert(OrganizationUsers obj)
        {
            context.OrganizationUsers.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(OrganizationUsers obj)
        {
            context.OrganizationUsers.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.OrganizationUsers.Find(id);
            context.OrganizationUsers.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
