using BugTracker.BOL;
using BugTracker.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    public interface IProjectUserDb
    {
        IEnumerable<ProjectUser> GetAll();
        ProjectUser GetById(int id);
        bool Insert(ProjectUser obj);
        bool Update(ProjectUser obj);
        bool Delete(int id);
    }
    public class ProjectUserDb : IProjectUserDb
    {
        private AppDbContext context;
        public ProjectUserDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<ProjectUser> GetAll()
        {
            return context.ProjectUser.ToList();
        }
        public ProjectUser GetById(int id)
        {
            var obj = context.ProjectUser.Find(id);
            return obj;
        }
        public bool Insert(ProjectUser obj)
        {
            context.ProjectUser.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(ProjectUser obj)
        {
            context.ProjectUser.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.ProjectUser.Find(id);
            context.ProjectUser.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
