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
    /// Represents the business logic operations for tasks.
    /// </summary>
    public interface ITasksBs
    {
        /// <summary>
        /// Gets all tasks.
        /// </summary>
        /// <returns>The collection of tasks.</returns>
        IEnumerable<Tasks> GetAll();

        /// <summary>
        /// Gets a task by ID.
        /// </summary>
        /// <param name="id">The ID of the task.</param>
        /// <returns>The task.</returns>
        Tasks GetById(int id);

        /// <summary>
        /// Inserts a new task.
        /// </summary>
        /// <param name="obj">The task object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Insert(Tasks obj);

        /// <summary>
        /// Updates an existing task.
        /// </summary>
        /// <param name="obj">The task object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Update(Tasks obj);

        /// <summary>
        /// Deletes a task by ID.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(int id);
    }

    /// <summary>
    /// Represents the implementation of the tasks business logic operations.
    /// </summary>
    public class TasksBs : ITasksBs
    {
        private readonly ITasksDb objDb;

        /// <summary>
        /// Initializes a new instance of the TasksBs class with the specified tasks database.
        /// </summary>
        /// <param name="_objDb">The tasks database implementation.</param>
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
