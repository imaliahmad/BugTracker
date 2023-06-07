using BugTracker.BOL;
using BugTracker.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    public interface IProjectsDb
    {
        IEnumerable<Projects> GetAll();
        Projects GetById(int id);
        bool Insert(Projects obj);
        bool Update(Projects obj);
        bool Delete(int id);
    }
    public class ProjectsDb : IProjectsDb
    {
        private AppDbContext context;
        public ProjectsDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Projects> GetAll()
        {
            return context.Projects.ToList();
        }
        public Projects GetById(int id)
        {
            var obj = context.Projects.Find(id);
            return obj;
        }
        public bool Insert(Projects obj)
        {
            context.Projects.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(Projects obj)
        {
            context.Projects.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.Projects.Find(id);
            context.Projects.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
