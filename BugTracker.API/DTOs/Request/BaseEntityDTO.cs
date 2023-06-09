using System.ComponentModel.DataAnnotations;

namespace BugTracker.API.DTOs.Request
{
    /// <summary>
    /// Represents the base entity DTO.
    /// </summary>
    public class BaseEntityDTO
    {
        /// <summary>
        /// Gets or sets the ID of the entity.
        /// </summary>
        [Key]
        public Guid Id { get; set; }
    }
}
