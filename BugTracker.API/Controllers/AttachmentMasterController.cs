using BugTracker.API.DTOs.Request;
using BugTracker.BLL;
using BugTracker.BOL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentMasterController : ControllerBase
    {
        private readonly IAttachmentMasterBs AttachmentMasterBs;

        public AttachmentMasterController(IAttachmentMasterBs _AttachmentMasterBs)
        {
            AttachmentMasterBs = _AttachmentMasterBs;
        }

        /// <summary>
        /// Retrieves all AttachmentMaster
        /// </summary>
        /// <returns>The list of AttachmentMaster.</returns>
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                AttachmentMaster[] AttachmentMasterList = AttachmentMasterBs.GetAll().ToArray();
                List<AttachmentMasterDTO> AttachmentMasterDTOList = new List<AttachmentMasterDTO>();
                foreach (var item in AttachmentMasterList)
                {
                    AttachmentMasterDTOList.Add(AttachmentMasterDTO.ToAttachmentMasterDTO(item));
                }

                return Ok(AttachmentMasterDTOList.ToArray());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves an AttachmentMaster by ID.
        /// </summary>
        /// <param name="id">The ID of the AttachmentMaster.</param>
        /// <returns>The AttachmentMaster.</returns>
        [HttpGet]
        [Route("getById/{Id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var AttachmentMaster = AttachmentMasterBs.GetById(id);
                AttachmentMasterDTO AttachmentMasterDTO = AttachmentMasterDTO.ToAttachmentMasterDTO(AttachmentMaster);

                return Ok(AttachmentMasterDTO);
            }
            catch (Exception ex)
            {
                return NotFound();

            }
        }

        /// <summary>
        /// Creates a new AttachmentMaster.
        /// </summary>
        /// <param name="attachmentMasterDTO">The AttachmentMaster data.</param>
        /// <returns>The created AttachmentMaster.</returns>

        [HttpPost]
        [Route("create")]
        public IActionResult Create(AttachmentMasterDTO AttachmentMasterDTO)
        {
            try
            {
                AttachmentMaster AttachmentMaster = AttachmentMasterBs.Insert(
                                         AttachmentMasterDTO.ToAttachmentMasterModel(AttachmentMasterDTO)
                                    );

                AttachmentMasterDTO = AttachmentMasterDTO.ToAttachmentMasterDTO(AttachmentMaster);

                return Ok(AttachmentMasterDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing AttachmentMaster.
        /// </summary>
        /// <param name="taskDto">The AttachmentMaster data to update.</param>
        /// <returns>The updated AttachmentMaster.</returns>
        [HttpPut]
        [Route("update")]
        public IActionResult Update(AttachmentMasterDTO AttachmentMasterDTO)
        {
            try
            {
                AttachmentMaster AttachmentMaster = AttachmentMasterBs.Update(
                                         AttachmentMasterDTO.ToAttachmentMasterModel(AttachmentMasterDTO)
                                    );

                AttachmentMasterDTO = AttachmentMasterDTO.ToAttachmentMasterDTO(AttachmentMaster);

                return Ok(AttachmentMasterDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an AttachmentMaster by ID.
        /// </summary>
        /// <param name="id">The ID of the AttachmentMaster to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        [HttpDelete]
        [Route("delete/{Id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var users = AttachmentMasterBs.Delete(id);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
