using BugTracker.BOL;
using BugTracker.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    public interface IOrganizationRolesDb
    {
        IEnumerable<OrganizationRoles> GetAll();
        OrganizationRoles GetById(int id);
        bool Insert(OrganizationRoles obj);
        bool Update(OrganizationRoles obj);
        bool Delete(int id);
    }
    public class OrganizationRolesDb : IOrganizationRolesDb
    {
        private AppDbContext context;
        public OrganizationRolesDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<OrganizationRoles> GetAll()
        {
            return context.OrganizationRoles.ToList();
        }
        public OrganizationRoles GetById(int id)
        {
            var obj = context.OrganizationRoles.Find(id);
            return obj;
        }
        public bool Insert(OrganizationRoles obj)
        {
            context.OrganizationRoles.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(OrganizationRoles obj)
        {
            context.OrganizationRoles.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.OrganizationRoles.Find(id);
            context.OrganizationRoles.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
