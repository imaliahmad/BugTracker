using BugTracker.BOL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.API.DTOs.Request
{
    /// <summary>
    /// Represents the DTO for AppUsers.
    /// </summary>
    public class AppUsersDTO: BaseEntityDTO
    {
        /// <summary>
        /// Gets or sets the name of user
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the id of organization (foreign key)
        /// </summary>
        public Guid OrgId { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        /* Navigations */

        /// <summary>
        /// Gets or sets the organization associated with the user.
        /// </summary>
        [ForeignKey("OrgId")]
        public virtual Organizations? Organizations { get; set; }

        /// <summary>
        /// Gets or sets the collection of project users associated with the user.
        /// </summary>
        public virtual IEnumerable<ProjectUser>? ProjectUser { get; set; }

        /// <summary>
        /// Converts an AppUsersDTO object to an AppUsers model.
        /// </summary>
        /// <param name="orgDTO">The AppUsersDTO object to convert.</param>
        /// <returns>The converted AppUsers model.</returns>
        public static AppUsers ToAppUsersModel(AppUsersDTO userDTO)
        {
            var user = new AppUsers();
            user.Id = userDTO.Id;
            user.Name = userDTO.Name;
            user.OrgId = userDTO.OrgId;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            

            return user;
        }

        /// <summary>
        /// Converts an AppUsers model to an AppUsersDTO object.
        /// </summary>
        /// <param name="model">The AppUsers model to convert.</param>
        /// <returns>The converted AppUsersDTO object.</returns>
        public static AppUsersDTO ToAppUsersDTO(AppUsers model)
        {
            var userDTO = new AppUsersDTO();
            userDTO.Id = model.Id;
            userDTO.Name = model.Name;
            userDTO.OrgId = model.OrgId;
            userDTO.Email = model.Email;
            userDTO.Password = model.Password;

            return userDTO;
        }
    }
}
