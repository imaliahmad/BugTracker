using AutoMapper;
using BugTracker.BOL;

namespace BugTracker.API.DTOs.Request
{
    public class OrganizationsDTO:BaseEntityDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double ContactNo { get; set; }

        public static Organizations ToOrganizationsModel(OrganizationsDTO orgDTO)
        {
            var org = new Organizations();
            org.Id= orgDTO.Id;
            org.Name = orgDTO.Name;
            org.Email = orgDTO.Email;
            org.ContactNo = orgDTO.ContactNo;
           

            return org;
        }
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
