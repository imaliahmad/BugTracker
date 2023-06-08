using BugTracker.BOL;
using BugTracker.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    public interface ITaskCommentsDb
    {
        IEnumerable<TaskComments> GetAll();
        TaskComments GetById(int id);
        bool Insert(TaskComments obj);
        bool Update(TaskComments obj);
        bool Delete(int id);
    }
    public class TaskCommentsDb : ITaskCommentsDb
    {
        private AppDbContext context;
        public TaskCommentsDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<TaskComments> GetAll()
        {
            return context.TaskComments.ToList();
        }
        public TaskComments GetById(int id)
        {
            var obj = context.TaskComments.Find(id);
            return obj;
        }
        public bool Insert(TaskComments obj)
        {
            context.TaskComments.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(TaskComments obj)
        {
            context.TaskComments.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.TaskComments.Find(id);
            context.TaskComments.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
