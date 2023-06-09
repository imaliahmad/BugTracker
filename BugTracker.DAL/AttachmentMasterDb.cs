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
    /// Represents the database operations for attachment masters.
    /// </summary>
    public interface IAttachmentMasterDb
    {
        /// <summary>
        /// Gets all the attachment masters.
        /// </summary>
        /// <returns>The collection of attachment masters.</returns>
        IEnumerable<AttachmentMaster> GetAll();

        /// <summary>
        /// Gets an attachment master by ID.
        /// </summary>
        /// <param name="id">The ID of the attachment master.</param>
        /// <returns>The attachment master.</returns>
        AttachmentMaster GetById(int id);

        /// <summary>
        /// Inserts a new attachment master.
        /// </summary>
        /// <param name="obj">The attachment master object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Insert(AttachmentMaster obj);

        /// <summary>
        /// Updates an existing attachment master.
        /// </summary>
        /// <param name="obj">The attachment master object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Update(AttachmentMaster obj);

        /// <summary>
        /// Deletes an attachment master by ID.
        /// </summary>
        /// <param name="id">The ID of the attachment master to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(int id);
    }

    /// <summary>
    /// Represents the implementation of the attachment masters database operations.
    /// </summary>
    public class AttachmentMasterDb : IAttachmentMasterDb
    {
        private AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the AttachmentMasterDb class with the specified database context.
        /// </summary>
        /// <param name="_context">The application database context.</param>
        public AttachmentMasterDb(AppDbContext _context)
        {
            context = _context;
        }

        
        public IEnumerable<AttachmentMaster> GetAll()
        {
            return context.AttachmentMaster.ToList();
        }

        
        public AttachmentMaster GetById(int id)
        {
            var obj = context.AttachmentMaster.Find(id);
            return obj;
        }

        
        public bool Insert(AttachmentMaster obj)
        {
            context.AttachmentMaster.Add(obj);
            context.SaveChanges();
            return true;
        }

        
        public bool Update(AttachmentMaster obj)
        {
            context.AttachmentMaster.Update(obj);
            context.SaveChanges();
            return true;
        }

        
        public bool Delete(int id)
        {
            var obj = context.AttachmentMaster.Find(id);
            context.AttachmentMaster.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
