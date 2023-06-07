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
        IEnumerable<TaskDetail> GetAll();
        TaskDetail GetById(int id);
        bool Insert(TaskDetail obj);
        bool Update(TaskDetail obj);
        bool Delete(int id);
    }
    public class TaskDetailDb : ITaskDetailDb
    {
        private AppDbContext context;
        public TaskDetailDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<TaskDetail> GetAll()
        {
            return context.TaskDetail.ToList();
        }
        public TaskDetail GetById(int id)
        {
            var obj = context.TaskDetail.Find(id);
            return obj;
        }
        public bool Insert(TaskDetail obj)
        {
            context.TaskDetail.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(TaskDetail obj)
        {
            context.TaskDetail.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.TaskDetail.Find(id);
            context.TaskDetail.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
