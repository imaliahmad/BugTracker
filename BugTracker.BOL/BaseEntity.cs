using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
    /// <summary>
    /// Base class for entities in the BugTracker system.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the entity.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the BaseEntity class.
        /// </summary>
        public BaseEntity()
        {

        }

        /// <summary>
        /// Initializes a new instance of the BaseEntity class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        public BaseEntity(Guid id)
        {
            Id = id;
        }
    }
}
