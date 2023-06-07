using BugTracker.BOL;
using BugTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BLL
{
    public interface IOrganizationRolesBs
    {
        IEnumerable<OrganizationRoles> GetAll();
        OrganizationRoles GetById(int id);
        bool Insert(OrganizationRoles obj);
        bool Update(OrganizationRoles obj);
        bool Delete(int id);
    }
    public class OrganizationRolesBs : IOrganizationRolesBs
    {
        private readonly IOrganizationRolesDb objDb;

        public OrganizationRolesBs(IOrganizationRolesDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<OrganizationRoles> GetAll()
        {
            return objDb.GetAll();
        }
        public OrganizationRoles GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(OrganizationRoles obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(OrganizationRoles obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
