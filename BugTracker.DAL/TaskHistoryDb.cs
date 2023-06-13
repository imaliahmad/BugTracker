using BugTracker.BOL;
using BugTracker.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    /// <summary>
    /// Represents the database operations for task history details.
    /// </summary>
    public interface ITaskDetailDb
    {
        /// <summary>
        /// Gets all the task history details.
        /// </summary>
        /// <returns>The collection of task history details.</returns>
        IEnumerable<TaskHistory> GetAll();

        /// <summary>
        /// Gets a task history detail by ID.
        /// </summary>
        /// <param name="id">The ID of the task history detail.</param>
        /// <returns>The task history detail.</returns>
        TaskHistory GetById(int id);

        /// <summary>
        /// Inserts a new task history detail.
        /// </summary>
        /// <param name="obj">The task history detail object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Insert(TaskHistory obj);

        /// <summary>
        /// Updates an existing task history detail.
        /// </summary>
        /// <param name="obj">The task history detail object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Update(TaskHistory obj);

        /// <summary>
        /// Deletes a task history detail by ID.
        /// </summary>
        /// <param name="id">The ID of the task history detail to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(int id);
    }

    /// <summary>
    /// Represents the implementation of the task history details database operations.
    /// </summary>
    public class TaskHistoryDb : ITaskDetailDb
    {
        private AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the TaskDetailDb class with the specified database context.
        /// </summary>
        /// <param name="_context">The application database context.</param>
        public TaskHistoryDb(AppDbContext _context)
        {
            context = _context;
        }

        
        public IEnumerable<TaskHistory> GetAll()
        {
            return context.TaskHistory.ToList();
        }

        
        public TaskHistory GetById(int id)
        {
            var obj = context.TaskHistory.Find(id);
            return obj;
        }

        
        public bool Insert(TaskHistory obj)
        {
            context.TaskHistory.Add(obj);
            context.SaveChanges();
            return true;
        }

        
        public bool Update(TaskHistory obj)
        {
            context.TaskHistory.Update(obj);
            context.SaveChanges();
            return true;
        }

       
        public bool Delete(int id)
        {
            var obj = context.TaskHistory.Find(id);
            context.TaskHistory.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
