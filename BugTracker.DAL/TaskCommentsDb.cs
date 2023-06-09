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
    /// Represents the database operations for task comments.
    /// </summary>
    public interface ITaskCommentsDb
    {
        /// <summary>
        /// Gets all the task comments.
        /// </summary>
        /// <returns>The collection of task comments.</returns>
        IEnumerable<TaskComments> GetAll();

        /// <summary>
        /// Gets a task comment by ID.
        /// </summary>
        /// <param name="id">The ID of the task comment.</param>
        /// <returns>The task comment.</returns>
        TaskComments GetById(int id);

        /// <summary>
        /// Inserts a new task comment.
        /// </summary>
        /// <param name="obj">The task comment object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Insert(TaskComments obj);

        /// <summary>
        /// Updates an existing task comment.
        /// </summary>
        /// <param name="obj">The task comment object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Update(TaskComments obj);

        /// <summary>
        /// Deletes a task comment by ID.
        /// </summary>
        /// <param name="id">The ID of the task comment to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(int id);
    }

    /// <summary>
    /// Represents the implementation of the task comments database operations.
    /// </summary>
    public class TaskCommentsDb : ITaskCommentsDb
    {
        private AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the TaskCommentsDb class with the specified database context.
        /// </summary>
        /// <param name="_context">The application database context.</param>
        public TaskCommentsDb(AppDbContext _context)
        {
            context = _context;
        }

       
        public IEnumerable<TaskComments> GetAll()
        {
            return context.TaskComments.ToList();
        }

        
        public TaskComments GetById(int id)
        {
            var obj = context.TaskComments.Find(id);
            return obj;
        }

        
        public bool Insert(TaskComments obj)
        {
            context.TaskComments.Add(obj);
            context.SaveChanges();
            return true;
        }

        
        public bool Update(TaskComments obj)
        {
            context.TaskComments.Update(obj);
            context.SaveChanges();
            return true;
        }

        
        public bool Delete(int id)
        {
            var obj = context.TaskComments.Find(id);
            context.TaskComments.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
