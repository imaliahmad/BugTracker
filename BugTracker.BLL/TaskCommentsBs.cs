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
    /// Represents the business logic operations for task comments.
    /// </summary>
    public interface ITaskCommentsBs
    {
        /// <summary>
        /// Gets all task comments.
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
    /// Represents the implementation of the task comments business logic operations.
    /// </summary>
    public class TaskCommentsBs : ITaskCommentsBs
    {
        private readonly ITaskCommentsDb objDb;

        /// <summary>
        /// Initializes a new instance of the TaskCommentsBs class with the specified task comments database.
        /// </summary>
        /// <param name="_objDb">The task comments database implementation.</param>
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
