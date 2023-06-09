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
    public interface IOrganizationUsersBs
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
        AppUsers GetById(int id);

        /// <summary>
        /// Inserts a new organization user.
        /// </summary>
        /// <param name="obj">The organization user object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Insert(AppUsers obj);

        /// <summary>
        /// Updates an existing organization user.
        /// </summary>
        /// <param name="obj">The organization user object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Update(AppUsers obj);

        /// <summary>
        /// Deletes an organization user by ID.
        /// </summary>
        /// <param name="id">The ID of the organization user to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(int id);
    }

    /// <summary>
    /// Represents the implementation of the organization users business logic operations.
    /// </summary>
    public class AppUsersBs : IOrganizationUsersBs
    {
        private readonly IOrganizationUsersDb objDb;

        /// <summary>
        /// Initializes a new instance of the AppUsersBs class with the specified organization users database.
        /// </summary>
        /// <param name="_objDb">The organization users database implementation.</param>
        public AppUsersBs(IOrganizationUsersDb _objDb)
        {
            objDb = _objDb;
        }

        
        public IEnumerable<AppUsers> GetAll()
        {
            return objDb.GetAll();
        }

        
        public AppUsers GetById(int id)
        {
            return objDb.GetById(id);
        }

       
        public bool Insert(AppUsers obj)
        {
            return objDb.Insert(obj);
        }

        
        public bool Update(AppUsers obj)
        {
            return objDb.Update(obj);
        }

        
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
