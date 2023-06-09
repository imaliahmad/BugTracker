using BugTracker.BOL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.API.DTOs.Request
{
    public class AppUsersDTO: BaseEntityDTO
    {
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the organization ID (foreign key).
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
        public virtual IEnumerable<ProjectUser> ProjectUser { get; set; }

        /// <summary>
        /// Converts an OrganizationsDTO object to an Organizations model.
        /// </summary>
        /// <param name="orgDTO">The OrganizationsDTO object to convert.</param>
        /// <returns>The converted Organizations model.</returns>
        public static AppUsers ToAppUsersModel(AppUsersDTO userDTO)
        {
            var user = new AppUsers();
            user.Id = userDTO.Id;
            user.OrgId = userDTO.OrgId;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            

            return user;
        }

        /// <summary>
        /// Converts an Organizations model to an OrganizationsDTO object.
        /// </summary>
        /// <param name="model">The Organizations model to convert.</param>
        /// <returns>The converted OrganizationsDTO object.</returns>
        public static AppUsersDTO ToAppUsersDTO(AppUsers model)
        {
            var userDTO = new AppUsersDTO();
            userDTO.Id = model.Id;
            userDTO.OrgId = model.OrgId;
            userDTO.Email = model.Email;
            userDTO.Password = model.Password;

            return userDTO;
        }
    }
}
