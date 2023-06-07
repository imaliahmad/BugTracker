using BugTracker.BOL;
using BugTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BLL
{
    public interface ITaskDetailBs
    {
        IEnumerable<TaskDetail> GetAll();
        TaskDetail GetById(int id);
        bool Insert(TaskDetail obj);
        bool Update(TaskDetail obj);
        bool Delete(int id);
    }
    public class TaskDetailBs : ITaskDetailBs
    {
        private readonly ITaskDetailDb objDb;

        public TaskDetailBs(ITaskDetailDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<TaskDetail> GetAll()
        {
            return objDb.GetAll();
        }
        public TaskDetail GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(TaskDetail obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(TaskDetail obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
