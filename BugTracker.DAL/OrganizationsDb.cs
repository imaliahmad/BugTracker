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
    /// Represents the database operations for organizations.
    /// </summary>
    public interface IOrganizationsDb
    {
        /// <summary>
        /// Gets all the organizations.
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
    /// Represents the implementation of the organizations database operations.
    /// </summary>
    public class OrganizationsDb : IOrganizationsDb
    {
        private AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the OrganizationsDb class with the specified database context.
        /// </summary>
        /// <param name="_context">The application database context.</param>
        public OrganizationsDb(AppDbContext _context)
        {
            context = _context;
        }

        
        public IEnumerable<Organizations> GetAll()
        {
            return context.Organizations.ToList();
        }

        
        public Organizations GetById(Guid id)
        {
            var obj = context.Organizations.Find(id);
            return obj;
        }

       
        public Organizations Insert(Organizations obj)
        {
            context.Organizations.Add(obj);
            context.SaveChanges();
            return obj;
        }

        
        public Organizations Update(Organizations obj)
        {
            context.Organizations.Update(obj);
            context.SaveChanges();
            return obj;
        }

        
        public bool Delete(Guid id)
        {
            var obj = context.Organizations.Find(id);
            context.Organizations.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
