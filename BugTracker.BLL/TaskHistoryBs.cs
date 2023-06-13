using BugTracker.BOL;
using BugTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BLL
{
    /// <summary>
    /// Represents the business logic operations for task details.
    /// </summary>
    public interface ITaskHistoryBs
    {
        /// <summary>
        /// Gets all task histories.
        /// </summary>
        /// <returns>The collection of task histories.</returns>
        IEnumerable<TaskHistory> GetAll();

        /// <summary>
        /// Gets a task history by ID.
        /// </summary>
        /// <param name="id">The ID of the task history.</param>
        /// <returns>The task history.</returns>
        TaskHistory GetById(Guid id);

        /// <summary>
        /// Inserts a new task history.
        /// </summary>
        /// <param name="obj">The task history object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        TaskHistory Insert(TaskHistory obj);

        /// <summary>
        /// Updates an existing task history.
        /// </summary>
        /// <param name="obj">The task history object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        TaskHistory Update(TaskHistory obj);

        /// <summary>
        /// Deletes a task history by ID.
        /// </summary>
        /// <param name="id">The ID of the task history to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// Represents the implementation of the task details business logic operations.
    /// </summary>
    public class TaskHistoryBs : ITaskHistoryBs
    {
        private readonly ITaskHistoryDb objDb;

        /// <summary>
        /// Initializes a new instance of the TaskDetailBs class with the specified task details database.
        /// </summary>
        /// <param name="_objDb">The task details database implementation.</param>
        public TaskHistoryBs(ITaskHistoryDb _objDb)
        {
            objDb = _objDb;
        }

        
        public IEnumerable<TaskHistory> GetAll()
        {
            return objDb.GetAll();
        }

        
        public TaskHistory GetById(Guid id)
        {
            return objDb.GetById(id);
        }

        
        public TaskHistory Insert(TaskHistory obj)
        {
            return objDb.Insert(obj);
        }

        
        public TaskHistory Update(TaskHistory obj)
        {
            return objDb.Update(obj);
        }

       
        public bool Delete(Guid id)
        {
            return objDb.Delete(id);
        }
    }
}
