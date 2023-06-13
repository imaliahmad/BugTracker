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
    /// Represents the business logic operations for attachment masters.
    /// </summary>
    public interface IAttachmentMasterBs
    {
        /// <summary>
        /// Gets all attachment masters.
        /// </summary>
        /// <returns>The collection of attachment masters.</returns>
        IEnumerable<AttachmentMaster> GetAll();

        /// <summary>
        /// Gets an attachment master by ID.
        /// </summary>
        /// <param name="id">The ID of the attachment master.</param>
        /// <returns>The attachment master.</returns>
        AttachmentMaster GetById(Guid id);

        /// <summary>
        /// Inserts a new attachment master.
        /// </summary>
        /// <param name="obj">The attachment master object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        AttachmentMaster Insert(AttachmentMaster obj);

        /// <summary>
        /// Updates an existing attachment master.
        /// </summary>
        /// <param name="obj">The attachment master object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        AttachmentMaster Update(AttachmentMaster obj);

        /// <summary>
        /// Deletes an attachment master by ID.
        /// </summary>
        /// <param name="id">The ID of the attachment master to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// Represents the implementation of the attachment masters business logic operations.
    /// </summary>
    public class AttachmentMasterBs : IAttachmentMasterBs
    {
        private readonly IAttachmentMasterDb objDb;

        /// <summary>
        /// Initializes a new instance of the AttachmentMasterBs class with the specified attachment master database.
        /// </summary>
        /// <param name="_objDb">The attachment master database implementation.</param>
        public AttachmentMasterBs(IAttachmentMasterDb _objDb)
        {
            objDb = _objDb;
        }
 
       
        public IEnumerable<AttachmentMaster> GetAll()
        {
            return objDb.GetAll();
        }

       
        public AttachmentMaster GetById(Guid id)
        {
            return objDb.GetById(id);
        }

        
        public AttachmentMaster Insert(AttachmentMaster obj)
        {
            return objDb.Insert(obj);
        }

        
        public AttachmentMaster Update(AttachmentMaster obj)
        {
            return objDb.Update(obj);
        }

        public bool Delete(Guid id)
        {
            return objDb.Delete(id);
        }
    }
}
