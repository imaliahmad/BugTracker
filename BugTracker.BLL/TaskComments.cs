using BugTracker.BOL;
using BugTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BLL
{
    public interface ITaskCommentsBs
    {
        IEnumerable<TaskComments> GetAll();
        TaskComments GetById(int id);
        bool Insert(TaskComments obj);
        bool Update(TaskComments obj);
        bool Delete(int id);
    }
    public class TaskCommentsBs : ITaskCommentsBs
    {
        private readonly ITaskCommentsDb objDb;

        public TaskCommentsBs(ITaskCommentsDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<TaskComments> GetAll()
        {
            return objDb.GetAll();
        }
        public TaskComments GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(TaskComments obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(TaskComments obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
