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
        IEnumerable<AppUsers> GetAll();
        AppUsers GetById(int id);
        bool Insert(AppUsers obj);
        bool Update(AppUsers obj);
        bool Delete(int id);
    }
    public class AppUsersBs : IOrganizationUsersBs
    {
        private readonly IOrganizationUsersDb objDb;

        public AppUsersBs(IOrganizationUsersDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<AppUsers> GetAll()
        {
            return objDb.GetAll();
        }
        public AppUsers GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(AppUsers obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(AppUsers obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
