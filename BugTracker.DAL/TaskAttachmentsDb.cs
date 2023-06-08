using BugTracker.BOL;
using BugTracker.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    public interface ITaskAttachmentsDb
    {
        IEnumerable<TaskAttachments> GetAll();
        TaskAttachments GetById(int id);
        bool Insert(TaskAttachments obj);
        bool Update(TaskAttachments obj);
        bool Delete(int id);
    }
    public class TaskAttachmentsDb : ITaskAttachmentsDb
    {
        private AppDbContext context;
        public TaskAttachmentsDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<TaskAttachments> GetAll()
        {
            return context.TaskAttachments.ToList();
        }
        public TaskAttachments GetById(int id)
        {
            var obj = context.TaskAttachments.Find(id);
            return obj;
        }
        public bool Insert(TaskAttachments obj)
        {
            context.TaskAttachments.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(TaskAttachments obj)
        {
            context.TaskAttachments.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.TaskAttachments.Find(id);
            context.TaskAttachments.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
