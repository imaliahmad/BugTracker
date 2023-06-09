using BugTracker.API.DTOs.Request;
using BugTracker.BLL;
using BugTracker.BOL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BugTracker.API.Controllers
{
    /// <summary>
    /// Represents the controller for managing organizations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationsBs organizationsBs;

        public OrganizationsController(IOrganizationsBs _organizationsBs)
        {
            organizationsBs = _organizationsBs;
        }

        /// <summary>
        /// Retrieves all organizations.
        /// </summary>
        /// <returns>The list of organizations.</returns>
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

        /// <summary>
        /// Retrieves an organization by ID.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <returns>The organization.</returns>
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

        /// <summary>
        /// Creates a new organization.
        /// </summary>
        /// <param name="orgDTO">The organization data.</param>
        /// <returns>The created organization.</returns>
        [HttpPost]
        [Route("create")]
        public IActionResult Create(OrganizationsDTO orgDTO)
        {
            try
            {
                Organizations organizations = organizationsBs.Insert(OrganizationsDTO.ToOrganizationsModel(orgDTO));

                orgDTO = OrganizationsDTO.ToOrganizationsDTO(organizations);
                return Ok(orgDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing organization.
        /// </summary>
        /// <param name="orgDto">The organization data to update.</param>
        /// <returns>The updated organization.</returns>
        [HttpPut]
        [Route("update")]
        public IActionResult Update(OrganizationsDTO orgDto)
        {
            try
            {
                Organizations organizations = organizationsBs.Update(OrganizationsDTO.ToOrganizationsModel(orgDto));

                orgDto = OrganizationsDTO.ToOrganizationsDTO(organizations);
                return Ok(orgDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an organization by ID.
        /// </summary>
        /// <param name="id">The ID of the organization to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
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
