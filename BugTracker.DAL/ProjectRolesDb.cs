using BugTracker.BOL;
using BugTracker.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    public interface IProjectRolesDb
    {
        IEnumerable<ProjectRoles> GetAll();
        ProjectRoles GetById(int id);
        bool Insert(ProjectRoles obj);
        bool Update(ProjectRoles obj);
        bool Delete(int id);
    }
    public class ProjectRolesDb : IProjectRolesDb
    {
        private AppDbContext context;
        public ProjectRolesDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<ProjectRoles> GetAll()
        {
            return context.ProjectRoles.ToList();
        }
        public ProjectRoles GetById(int id)
        {
            var obj = context.ProjectRoles.Find(id);
            return obj;
        }
        public bool Insert(ProjectRoles obj)
        {
            context.ProjectRoles.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(ProjectRoles obj)
        {
            context.ProjectRoles.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.ProjectRoles.Find(id);
            context.ProjectRoles.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
