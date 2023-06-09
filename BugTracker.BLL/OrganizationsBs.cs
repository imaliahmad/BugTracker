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
    /// Represents the business logic operations for organizations.
    /// </summary>
    public interface IOrganizationsBs
    {
        /// <summary>
        /// Gets all organizations.
        /// </summary>
        /// <returns>The collection of organizations.</returns>
        IEnumerable<Organizations> GetAll();

        /// <summary>
        /// Gets an organization by ID.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <returns>The organization.</returns>
        Organizations GetById(Guid id);

        /// <summary>
        /// Inserts a new organization.
        /// </summary>
        /// <param name="obj">The organization object to insert.</param>
        /// <returns>The inserted organization.</returns>
        Organizations Insert(Organizations obj);

        /// <summary>
        /// Updates an existing organization.
        /// </summary>
        /// <param name="obj">The organization object to update.</param>
        /// <returns>The updated organization.</returns>
        Organizations Update(Organizations obj);

        /// <summary>
        /// Deletes an organization by ID.
        /// </summary>
        /// <param name="id">The ID of the organization to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// Represents the implementation of the organizations business logic operations.
    /// </summary>
    public class OrganizationsBs : IOrganizationsBs
    {
        private readonly IOrganizationsDb objDb;

        /// <summary>
        /// Initializes a new instance of the OrganizationsBs class with the specified organizations database.
        /// </summary>
        /// <param name="_objDb">The organizations database implementation.</param>
        public OrganizationsBs(IOrganizationsDb _objDb)
        {
            objDb = _objDb;
        }

       
        public IEnumerable<Organizations> GetAll()
        {
            return objDb.GetAll();
        }

        
        public Organizations GetById(Guid id)
        {
            return objDb.GetById(id);
        }

      
        public Organizations Insert(Organizations obj)
        {
            return objDb.Insert(obj);
        }

        
        public Organizations Update(Organizations obj)
        {
            return objDb.Update(obj);
        }

        
        public bool Delete(Guid id)
        {
            return objDb.Delete(id);
        }
    }
}
