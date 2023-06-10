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
    /// Represents the business logic operations for projects.
    /// </summary>
    public interface IProjectsBs
    {
        /// <summary>
        /// Gets all projects.
        /// </summary>
        /// <returns>The collection of projects.</returns>
        IEnumerable<Projects> GetAll();

        /// <summary>
        /// Gets a project by ID.
        /// </summary>
        /// <param name="id">The ID of the project.</param>
        /// <returns>The project.</returns>
        Projects GetById(Guid id);

        /// <summary>
        /// Inserts a new project.
        /// </summary>
        /// <param name="obj">The project object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        Projects Insert(Projects obj);

        /// <summary>
        /// Updates an existing project.
        /// </summary>
        /// <param name="obj">The project object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        Projects Update(Projects obj);

        /// <summary>
        /// Deletes a project by ID.
        /// </summary>
        /// <param name="id">The ID of the project to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// Represents the implementation of the projects business logic operations.
    /// </summary>
    public class ProjectsBs : IProjectsBs
    {
        private readonly IProjectsDb objDb;

        /// <summary>
        /// Initializes a new instance of the ProjectsBs class with the specified projects database.
        /// </summary>
        /// <param name="_objDb">The projects database implementation.</param>
        public ProjectsBs(IProjectsDb _objDb)
        {
            objDb = _objDb;
        }

        
        public IEnumerable<Projects> GetAll()
        {
            return objDb.GetAll();
        }

      
        public Projects GetById(Guid id)
        {
            return objDb.GetById(id);
        }

       
        public Projects Insert(Projects obj)
        {
            return objDb.Insert(obj);
        }

       
        public Projects Update(Projects obj)
        {
            return objDb.Update(obj);
        }

       
        public bool Delete(Guid id)
        {
            return objDb.Delete(id);
        }
    }
}
