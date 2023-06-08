using BugTracker.BOL;
using BugTracker.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    public interface ITaskDetailDb
    {
        IEnumerable<TaskHistory> GetAll();
        TaskHistory GetById(int id);
        bool Insert(TaskHistory obj);
        bool Update(TaskHistory obj);
        bool Delete(int id);
    }
    public class TaskDetailDb : ITaskDetailDb
    {
        private AppDbContext context;
        public TaskDetailDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<TaskHistory> GetAll()
        {
            return context.TaskHistory.ToList();
        }
        public TaskHistory GetById(int id)
        {
            var obj = context.TaskHistory.Find(id);
            return obj;
        }
        public bool Insert(TaskHistory obj)
        {
            context.TaskHistory.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(TaskHistory obj)
        {
            context.TaskHistory.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.TaskHistory.Find(id);
            context.TaskHistory.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
