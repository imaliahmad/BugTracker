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
    /// Represents the database operations for tasks.
    /// </summary>
    public interface ITasksDb
    {
        /// <summary>
        /// Gets all the tasks.
        /// </summary>
        /// <returns>The collection of tasks.</returns>
        IEnumerable<Tasks> GetAll();

        /// <summary>
        /// Gets a task by ID.
        /// </summary>
        /// <param name="id">The ID of the task.</param>
        /// <returns>The task.</returns>
        Tasks GetById(Guid id);

        /// <summary>
        /// Inserts a new task.
        /// </summary>
        /// <param name="obj">The task object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        Tasks Insert(Tasks obj);

        /// <summary>
        /// Updates an existing task.
        /// </summary>
        /// <param name="obj">The task object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        Tasks Update(Tasks obj);

        /// <summary>
        /// Deletes a task by ID.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// Represents the implementation of the tasks database operations.
    /// </summary>
    public class TasksDb : ITasksDb
    {
        private AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the TasksDb class with the specified database context.
        /// </summary>
        /// <param name="_context">The application database context.</param>
        public TasksDb(AppDbContext _context)
        {
            context = _context;
        }

       
        public IEnumerable<Tasks> GetAll()
        {
            return context.Tasks.ToList();
        }

       
        public Tasks GetById(Guid id)
        {
            var obj = context.Tasks.Find(id);
            return obj;
        }

       
        public Tasks Insert(Tasks obj)
        {
            context.Tasks.Add(obj);
            context.SaveChanges();
            return obj;
        }

        
        public Tasks Update(Tasks obj)
        {
            context.Tasks.Update(obj);
            context.SaveChanges();
            return obj;
        }

       
        public bool Delete(Guid id)
        {
            var obj = context.Tasks.Find(id);
            context.Tasks.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
