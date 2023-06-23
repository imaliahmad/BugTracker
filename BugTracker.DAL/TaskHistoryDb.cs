using BugTracker.BOL;
using BugTracker.DAL.Data;
using Microsoft.EntityFrameworkCore;
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
    public interface ITaskHistoryDb
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
        TaskHistory GetById(Guid id);

        /// <summary>
        /// Inserts a new task history detail.
        /// </summary>
        /// <param name="obj">The task history detail object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        TaskHistory Insert(TaskHistory obj);

        /// <summary>
        /// Updates an existing task history detail.
        /// </summary>
        /// <param name="obj">The task history detail object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        TaskHistory Update(TaskHistory obj);

        /// <summary>
        /// Deletes a task history detail by ID.
        /// </summary>
        /// <param name="id">The ID of the task history detail to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// Represents the implementation of the task history details database operations.
    /// </summary>
    public class TaskHistoryDb : ITaskHistoryDb
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
            var list = context.TaskHistory
                                                   .Include(t => t.Tasks)
                                                   .Include(u => u.ProjectUser.AppUsers)
                                                   .Select(x => new TaskHistory()
                                                   {
                                                       Id = x.Id,
                                                       
                                                       TaskId = x.TaskId,
                                                       Tasks = x.Tasks,
                                                       AssigneeId = x.AssigneeId,
                                                       ProjectUser = new ProjectUser()
                                                       {
                                                           Id = x.ProjectUser.Id,
                                                           ProjectId = x.ProjectUser.ProjectId,
                                                           UserId = x.ProjectUser.UserId,
                                                           AppUsers = x.ProjectUser.AppUsers
                                                       },
                                                      ModifiedDate = x.ModifiedDate,
                                                      Status = x.Status,
                                                   }).ToList();
            return list;
        }

        
        public TaskHistory GetById(Guid id)
        {
            var obj = context.TaskHistory.Find(id);
            return obj;
        }

        
        public TaskHistory Insert(TaskHistory obj)
        {
            context.TaskHistory.Add(obj);
            context.SaveChanges();
            return obj;
        }

        
        public TaskHistory Update(TaskHistory obj)
        {
            context.TaskHistory.Update(obj);
            context.SaveChanges();
            return obj;
        }

       
        public bool Delete(Guid id)
        {
            var obj = context.TaskHistory.Find(id);
            context.TaskHistory.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
