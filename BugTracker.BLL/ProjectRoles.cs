using BugTracker.BOL;
using BugTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BLL
{
    public interface IProjectRolesBs
    {
        IEnumerable<ProjectRoles> GetAll();
        ProjectRoles GetById(int id);
        bool Insert(ProjectRoles obj);
        bool Update(ProjectRoles obj);
        bool Delete(int id);
    }
    public class ProjectRolesBs : IProjectRolesBs
    {
        private readonly IProjectRolesDb objDb;

        public ProjectRolesBs(IProjectRolesDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<ProjectRoles> GetAll()
        {
            return objDb.GetAll();
        }
        public ProjectRoles GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(ProjectRoles obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(ProjectRoles obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
