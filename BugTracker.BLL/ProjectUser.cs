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
    /// Represents the business logic operations for project users.
    /// </summary>
    public interface IProjectUserBs
    {
        /// <summary>
        /// Gets all project users.
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
    /// Represents the implementation of the project users business logic operations.
    /// </summary>
    public class ProjectUserBs : IProjectUserBs
    {
        private readonly IProjectUserDb objDb;

        /// <summary>
        /// Initializes a new instance of the ProjectUserBs class with the specified project users database.
        /// </summary>
        /// <param name="_objDb">The project users database implementation.</param>
        public ProjectUserBs(IProjectUserDb _objDb)
        {
            objDb = _objDb;
        }

       
        public IEnumerable<ProjectUser> GetAll()
        {
            return objDb.GetAll();
        }

        
        public ProjectUser GetById(int id)
        {
            return objDb.GetById(id);
        }

        
        public bool Insert(ProjectUser obj)
        {
            return objDb.Insert(obj);
        }

        
        public bool Update(ProjectUser obj)
        {
            return objDb.Update(obj);
        }

       
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
