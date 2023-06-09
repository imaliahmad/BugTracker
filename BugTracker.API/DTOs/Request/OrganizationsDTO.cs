using AutoMapper;
using BugTracker.BOL;

namespace BugTracker.API.DTOs.Request
{
    /// <summary>
    /// Represents the DTO for Organizations.
    /// </summary>
    public class OrganizationsDTO : BaseEntityDTO
    {
        /// <summary>
        /// Gets or sets the name of the organization.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email of the organization.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the contact number of the organization.
        /// </summary>
        public double ContactNo { get; set; }

        /// <summary>
        /// Converts an OrganizationsDTO object to an Organizations model.
        /// </summary>
        /// <param name="orgDTO">The OrganizationsDTO object to convert.</param>
        /// <returns>The converted Organizations model.</returns>
        public static Organizations ToOrganizationsModel(OrganizationsDTO orgDTO)
        {
            var org = new Organizations();
            org.Id = orgDTO.Id;
            org.Name = orgDTO.Name;
            org.Email = orgDTO.Email;
            org.ContactNo = orgDTO.ContactNo;

            return org;
        }

        /// <summary>
        /// Converts an Organizations model to an OrganizationsDTO object.
        /// </summary>
        /// <param name="model">The Organizations model to convert.</param>
        /// <returns>The converted OrganizationsDTO object.</returns>
        public static OrganizationsDTO ToOrganizationsDTO(Organizations model)
        {
            var orgDTO = new OrganizationsDTO();
            orgDTO.Id = model.Id;
            orgDTO.Name = model.Name;
            orgDTO.Email = model.Email;
            orgDTO.ContactNo = model.ContactNo;

            return orgDTO;
        }
    }
}
