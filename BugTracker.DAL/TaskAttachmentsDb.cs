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
    /// Represents the database operations for task attachments.
    /// </summary>
    public interface ITaskAttachmentsDb
    {
        /// <summary>
        /// Gets all the task attachments.
        /// </summary>
        /// <returns>The collection of task attachments.</returns>
        IEnumerable<TaskAttachments> GetAll();

        /// <summary>
        /// Gets a task attachment by ID.
        /// </summary>
        /// <param name="id">The ID of the task attachment.</param>
        /// <returns>The task attachment.</returns>
        TaskAttachments GetById(int id);

        /// <summary>
        /// Inserts a new task attachment.
        /// </summary>
        /// <param name="obj">The task attachment object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Insert(TaskAttachments obj);

        /// <summary>
        /// Updates an existing task attachment.
        /// </summary>
        /// <param name="obj">The task attachment object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Update(TaskAttachments obj);

        /// <summary>
        /// Deletes a task attachment by ID.
        /// </summary>
        /// <param name="id">The ID of the task attachment to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(int id);
    }

    /// <summary>
    /// Represents the implementation of the task attachments database operations.
    /// </summary>
    public class TaskAttachmentsDb : ITaskAttachmentsDb
    {
        private AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the TaskAttachmentsDb class with the specified database context.
        /// </summary>
        /// <param name="_context">The application database context.</param>
        public TaskAttachmentsDb(AppDbContext _context)
        {
            context = _context;
        }

        
        public IEnumerable<TaskAttachments> GetAll()
        {
            return context.TaskAttachments.ToList();
        }

       
        public TaskAttachments GetById(int id)
        {
            var obj = context.TaskAttachments.Find(id);
            return obj;
        }

       
        public bool Insert(TaskAttachments obj)
        {
            context.TaskAttachments.Add(obj);
            context.SaveChanges();
            return true;
        }

       
        public bool Update(TaskAttachments obj)
        {
            context.TaskAttachments.Update(obj);
            context.SaveChanges();
            return true;
        }

       
        public bool Delete(int id)
        {
            var obj = context.TaskAttachments.Find(id);
            context.TaskAttachments.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
