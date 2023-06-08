﻿using BugTracker.BOL;
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
        IEnumerable<TaskHistory> GetAll();
        TaskHistory GetById(int id);
        bool Insert(TaskHistory obj);
        bool Update(TaskHistory obj);
        bool Delete(int id);
    }
    public class TaskDetailBs : ITaskDetailBs
    {
        private readonly ITaskDetailDb objDb;

        public TaskDetailBs(ITaskDetailDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<TaskHistory> GetAll()
        {
            return objDb.GetAll();
        }
        public TaskHistory GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(TaskHistory obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(TaskHistory obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
