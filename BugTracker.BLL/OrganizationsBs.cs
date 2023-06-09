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
        Organizations GetById(Guid id);
        Organizations Insert(Organizations obj);
        Organizations Update(Organizations obj);
        bool Delete(Guid id);
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
        public Organizations GetById(Guid id)
        {
            return objDb.GetById(id);
        }
        public Organizations Insert(Organizations obj)
        {
            return objDb.Insert(obj);
        }
        public Organizations Update(Organizations obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(Guid id)
        {
            return objDb.Delete(id);
        }
    }
}
