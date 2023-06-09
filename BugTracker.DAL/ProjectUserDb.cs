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
    /// Represents the database operations for project users.
    /// </summary>
    public interface IProjectUserDb
    {
        /// <summary>
        /// Gets all the project users.
        /// </summary>
        /// <returns>The collection of project users.</returns>
        IEnumerable<ProjectUser> GetAll();

        /// <summary>
        /// Gets a project user by ID.
        /// </summary>
        /// <param name="id">The ID of the project user.</param>
        /// <returns>The project user.</returns>
        ProjectUser GetById(int id);

        /// <summary>
        /// Inserts a new project user.
        /// </summary>
        /// <param name="obj">The project user object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Insert(ProjectUser obj);

        /// <summary>
        /// Updates an existing project user.
        /// </summary>
        /// <param name="obj">The project user object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Update(ProjectUser obj);

        /// <summary>
        /// Deletes a project user by ID.
        /// </summary>
        /// <param name="id">The ID of the project user to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(int id);
    }

    /// <summary>
    /// Represents the implementation of the project users database operations.
    /// </summary>
    public class ProjectUserDb : IProjectUserDb
    {
        private AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the ProjectUserDb class with the specified database context.
        /// </summary>
        /// <param name="_context">The application database context.</param>
        public ProjectUserDb(AppDbContext _context)
        {
            context = _context;
        }

        
        public IEnumerable<ProjectUser> GetAll()
        {
            return context.ProjectUser.ToList();
        }

        
        public ProjectUser GetById(int id)
        {
            var obj = context.ProjectUser.Find(id);
            return obj;
        }

       
        public bool Insert(ProjectUser obj)
        {
            context.ProjectUser.Add(obj);
            context.SaveChanges();
            return true;
        }

        
        public bool Update(ProjectUser obj)
        {
            context.ProjectUser.Update(obj);
            context.SaveChanges();
            return true;
        }

       
        public bool Delete(int id)
        {
            var obj = context.ProjectUser.Find(id);
            context.ProjectUser.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
