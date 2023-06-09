using BugTracker.API.DTOs.Request;
using BugTracker.BLL;
using BugTracker.BOL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationsBs organizationsBs;

        public OrganizationsController(IOrganizationsBs _organizationsBs)
        {
            organizationsBs = _organizationsBs;
        }
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                Organizations[] orgList = organizationsBs.GetAll().ToArray();
                List<OrganizationsDTO> orgDTOList = new List<OrganizationsDTO>();

                foreach (var item in orgList)
                {
                    orgDTOList.Add(OrganizationsDTO.ToOrganizationsDTO(item));
                }

                return Ok(orgDTOList.ToArray());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpGet]
        [Route("getById/{Id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var org = organizationsBs.GetById(id);
                OrganizationsDTO organizationsDTO = OrganizationsDTO.ToOrganizationsDTO(org);

                return Ok(organizationsDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create(OrganizationsDTO orgDTO)
        {
                try
                {
                  Organizations organizations = organizationsBs.Insert(
                                                       OrganizationsDTO.ToOrganizationsModel(orgDTO)
                                                 );

                   orgDTO = OrganizationsDTO.ToOrganizationsDTO(organizations);
                   return Ok(orgDTO);
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
           
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(OrganizationsDTO orgDto)
        {
            try
            {
                Organizations organizations = organizationsBs.Update(
                                                       OrganizationsDTO.ToOrganizationsModel(orgDto)
                                                 );

                orgDto = OrganizationsDTO.ToOrganizationsDTO(organizations);

                return Ok(orgDto);
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
        }
        [HttpDelete]
        [Route("delete/{Id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var org = organizationsBs.Delete(id);
                return Ok(org);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
