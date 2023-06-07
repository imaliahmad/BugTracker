using BugTracker.BOL;
using BugTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BLL
{
    public interface IProjectUserBs
    {
        IEnumerable<ProjectUser> GetAll();
        ProjectUser GetById(int id);
        bool Insert(ProjectUser obj);
        bool Update(ProjectUser obj);
        bool Delete(int id);
    }
    public class ProjectUserBs : IProjectUserBs
    {
        private readonly IProjectUserDb objDb;

        public ProjectUserBs(IProjectUserDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<ProjectUser> GetAll()
        {
            return objDb.GetAll();
        }
        public ProjectUser GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(ProjectUser obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(ProjectUser obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
