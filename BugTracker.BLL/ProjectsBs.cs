using BugTracker.BOL;
using BugTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BLL
{
    public interface IProjectsBs
    {
        IEnumerable<Projects> GetAll();
        Projects GetById(int id);
        bool Insert(Projects obj);
        bool Update(Projects obj);
        bool Delete(int id);
    }
    public class ProjectsBs : IProjectsBs
    {
        private readonly IProjectsDb objDb;

        public ProjectsBs(IProjectsDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<Projects> GetAll()
        {
            return objDb.GetAll();
        }
        public Projects GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(Projects obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(Projects obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
