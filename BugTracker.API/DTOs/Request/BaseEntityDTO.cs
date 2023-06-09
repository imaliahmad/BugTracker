using System.ComponentModel.DataAnnotations;

namespace BugTracker.API.DTOs.Request
{
    public class BaseEntityDTO
    {
        [Key]
        public Guid Id { get; set; }
    }
}
