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
    /// Represents the business logic operations for organization users.
    /// </summary>
    public interface IAppUsersBs
    {
        /// <summary>
        /// Gets all organization users.
        /// </summary>
        /// <returns>The collection of organization users.</returns>
        IEnumerable<AppUsers> GetAll();

        /// <summary>
        /// Gets an organization user by ID.
        /// </summary>
        /// <param name="id">The ID of the organization user.</param>
        /// <returns>The organization user.</returns>
        AppUsers GetById(Guid id);

        /// <summary>
        /// Inserts a new organization user.
        /// </summary>
        /// <param name="obj">The organization user object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        AppUsers Insert(AppUsers obj);

        /// <summary>
        /// Updates an existing organization user.
        /// </summary>
        /// <param name="obj">The organization user object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        AppUsers Update(AppUsers obj);

        /// <summary>
        /// Deletes an organization user by ID.
        /// </summary>
        /// <param name="id">The ID of the organization user to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// Represents the implementation of the organization users business logic operations.
    /// </summary>
    public class AppUsersBs : IAppUsersBs
    {
        private readonly IAppUsersDb objDb;

        /// <summary>
        /// Initializes a new instance of the AppUsersBs class with the specified organization users database.
        /// </summary>
        /// <param name="_objDb">The organization users database implementation.</param>
        public AppUsersBs(IAppUsersDb _objDb)
        {
            objDb = _objDb;
        }

        
        public IEnumerable<AppUsers> GetAll()
        {
            return objDb.GetAll();
        }

        
        public AppUsers GetById(Guid id)
        {
            return objDb.GetById(id);
        }

       
        public AppUsers Insert(AppUsers obj)
        {
            return objDb.Insert(obj);
        }

        
        public AppUsers Update(AppUsers obj)
        {
            return objDb.Update(obj);
        }

        
        public bool Delete(Guid id)
        {
            return objDb.Delete(id);
        }
    }
}
