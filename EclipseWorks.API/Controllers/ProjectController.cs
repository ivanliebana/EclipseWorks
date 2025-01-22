using AutoMapper;
using EclipseWorks.Core.Models;
using EclipseWorks.DTO.BaseDTO;
using EclipseWorks.DTO.Project;
using EclipseWorks.Services;
using EclipseWorks.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorks.API.Controllers
{
    public class ProjectController(
          IProjectService projectService,
          IMapper mapper) : CustomBaseController
    {
        private readonly IProjectService _projectService = projectService;
        private readonly IMapper _mapper = mapper;

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllByUser(long userId, CancellationToken ct)
        {
            var result = _mapper.Map<List<ProjectListingDTO>>(await _projectService.GetAllByUserAsync(userId, ct));

            if (result == null)
                return NotFound(new APIResponseDTO<List<ProjectListingDTO>>());

            return Ok(new APIResponseDTO<List<ProjectListingDTO>> { Success = true, Data = result });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectRegistrationDTO obj, CancellationToken ct)
        {
            if (obj == null)
                return BadRequest(new APIResponseDTO<ProjectRegistrationDTO>());

            await _projectService.AddAsync(_mapper.Map<ProjectModel>(obj), ct);
            return Ok(new APIResponseDTO<ProjectRegistrationDTO> { Success = true });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProjectEditDTO obj, CancellationToken ct)
        {
            if (obj == null)
                return BadRequest(new APIResponseDTO<ProjectEditDTO>());

            await _projectService.UpdateAsync(_mapper.Map<ProjectModel>(obj), ct);
            return Ok(new APIResponseDTO<ProjectEditDTO> { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id, CancellationToken ct)
        {
            var result = await _projectService.DeleteByIdAsync(id, ct);
            return Ok(new APIResponseDTO { Success = result });
        }
    }
}