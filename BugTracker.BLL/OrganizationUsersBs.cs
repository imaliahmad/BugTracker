using BugTracker.BOL;
using BugTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BLL
{
    public interface IOrganizationUsersBs
    {
        IEnumerable<OrganizationUsers> GetAll();
        OrganizationUsers GetById(int id);
        bool Insert(OrganizationUsers obj);
        bool Update(OrganizationUsers obj);
        bool Delete(int id);
    }
    public class OrganizationUsersBs : IOrganizationUsersBs
    {
        private readonly IOrganizationUsersDb objDb;

        public OrganizationUsersBs(IOrganizationUsersDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<OrganizationUsers> GetAll()
        {
            return objDb.GetAll();
        }
        public OrganizationUsers GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(OrganizationUsers obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(OrganizationUsers obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
