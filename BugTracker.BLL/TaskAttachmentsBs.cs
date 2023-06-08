using BugTracker.BOL;
using BugTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BLL
{
    public interface ITaskAttachmentsBs
    {
        IEnumerable<TaskAttachments> GetAll();
        TaskAttachments GetById(int id);
        bool Insert(TaskAttachments obj);
        bool Update(TaskAttachments obj);
        bool Delete(int id);
    }
    public class TaskAttachmentsBs : ITaskAttachmentsBs
    {
        private readonly ITaskAttachmentsDb objDb;

        public TaskAttachmentsBs(ITaskAttachmentsDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<TaskAttachments> GetAll()
        {
            return objDb.GetAll();
        }
        public TaskAttachments GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(TaskAttachments obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(TaskAttachments obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
