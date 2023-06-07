using BugTracker.BOL;
using BugTracker.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    public interface ITasksDb
    {
        IEnumerable<Tasks> GetAll();
        Tasks GetById(int id);
        bool Insert(Tasks obj);
        bool Update(Tasks obj);
        bool Delete(int id);
    }
    public class TasksDb : ITasksDb
    {
        private AppDbContext context;
        public TasksDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Tasks> GetAll()
        {
            return context.Tasks.ToList();
        }
        public Tasks GetById(int id)
        {
            var obj = context.Tasks.Find(id);
            return obj;
        }
        public bool Insert(Tasks obj)
        {
            context.Tasks.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(Tasks obj)
        {
            context.Tasks.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.Tasks.Find(id);
            context.Tasks.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
