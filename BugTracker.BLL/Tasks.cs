using BugTracker.BOL;
using BugTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BLL
{
    public interface ITasksBs
    {
        IEnumerable<Tasks> GetAll();
        Tasks GetById(int id);
        bool Insert(Tasks obj);
        bool Update(Tasks obj);
        bool Delete(int id);
    }
    public class TasksBs : ITasksBs
    {
        private readonly ITasksDb objDb;

        public TasksBs(ITasksDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<Tasks> GetAll()
        {
            return objDb.GetAll();
        }
        public Tasks GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(Tasks obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(Tasks obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
