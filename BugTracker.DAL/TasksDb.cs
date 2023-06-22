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
            var list = context.Tasks
                                       .Include(p => p.Projects)
                                       .Include(u => u.ProjectUser)
                                       .Select(x => new Tasks()
                                       {
                                           Id = x.Id,
                                           Name = x.Name,
                                           ProjectId = x.ProjectId,
                                           Projects = x.Projects,
                                           CreatedUserId = x.CreatedUserId,
                                           ProjectUser = x.ProjectUser,
                                           Description = x.Description,
                                           Priority = x.Priority,
                                           Type  = x.Type,
                                           TaskNo = x.TaskNo,



                                       }).ToList();
            return list;
        }

       
        public Tasks GetById(Guid id)
        {
            var obj = context.Tasks.Find(id);
            return obj;
        }

       
        public Tasks Insert(Tasks obj)
        {
            obj.TaskNo = GetUniqueTaskNumber();
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
        public string GetUniqueTaskNumber()
        {
            string task = "TK";
            string currentDate = DateTime.Now.ToString("ddMMyy");

            string latestTaskNumber = context.Tasks
                                                    .Where(a => a.TaskNo.StartsWith(task + "-" + currentDate))
                                                    .OrderByDescending(a => a.TaskNo)
                                                    .Select(a => a.TaskNo)
                                                    .FirstOrDefault();

            // D4 = 0000

            int sequenceNumber = 1;
            if (!string.IsNullOrEmpty(latestTaskNumber))
            {
                string sequencePart = latestTaskNumber.Substring(10, 4); // 0005 
                sequenceNumber = Convert.ToInt32(sequencePart) + 1; //6
            }
            // string.format("", D4)

            string newTaskNumber = $"{task}-{currentDate}-{sequenceNumber:D4}";
            return newTaskNumber;

        }
    }
}
