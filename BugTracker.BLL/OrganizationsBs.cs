using BugTracker.BOL;
using BugTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BLL
{
    public interface IOrganizationsBs
    {
        IEnumerable<Organizations> GetAll();
        Organizations GetById(int id);
        bool Insert(Organizations obj);
        bool Update(Organizations obj);
        bool Delete(int id);
    }
    public class OrganizationsBs : IOrganizationsBs
    {
        private readonly IOrganizationsDb objDb;

        public OrganizationsBs(IOrganizationsDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<Organizations> GetAll()
        {
            return objDb.GetAll();
        }
        public Organizations GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(Organizations obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(Organizations obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
