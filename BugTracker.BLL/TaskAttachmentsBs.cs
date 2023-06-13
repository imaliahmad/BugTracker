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
    /// Represents the business logic operations for task attachments.
    /// </summary>
    public interface ITaskAttachmentsBs
    {
        /// <summary>
        /// Gets all task attachments.
        /// </summary>
        /// <returns>The collection of task attachments.</returns>
        IEnumerable<TaskAttachments> GetAll();

        /// <summary>
        /// Gets a task attachment by ID.
        /// </summary>
        /// <param name="id">The ID of the task attachment.</param>
        /// <returns>The task attachment.</returns>
        TaskAttachments GetById(Guid id);

        /// <summary>
        /// Inserts a new task attachment.
        /// </summary>
        /// <param name="obj">The task attachment object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        TaskAttachments Insert(TaskAttachments obj);

        /// <summary>
        /// Updates an existing task attachment.
        /// </summary>
        /// <param name="obj">The task attachment object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        TaskAttachments Update(TaskAttachments obj);

        /// <summary>
        /// Deletes a task attachment by ID.
        /// </summary>
        /// <param name="id">The ID of the task attachment to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// Represents the implementation of the task attachments business logic operations.
    /// </summary>
    public class TaskAttachmentsBs : ITaskAttachmentsBs
    {
        private readonly ITaskAttachmentsDb objDb;

        /// <summary>
        /// Initializes a new instance of the TaskAttachmentsBs class with the specified task attachments database.
        /// </summary>
        /// <param name="_objDb">The task attachments database implementation.</param>
        public TaskAttachmentsBs(ITaskAttachmentsDb _objDb)
        {
            objDb = _objDb;
        }

       
        public IEnumerable<TaskAttachments> GetAll()
        {
            return objDb.GetAll();
        }

        
        public TaskAttachments GetById(Guid id)
        {
            return objDb.GetById(id);
        }

        
        public TaskAttachments Insert(TaskAttachments obj)
        {
            return objDb.Insert(obj);
        }

        
        public TaskAttachments Update(TaskAttachments obj)
        {
            return objDb.Update(obj);
        }

       
        public bool Delete(Guid id)
        {
            return objDb.Delete(id);
        }
    }
}
