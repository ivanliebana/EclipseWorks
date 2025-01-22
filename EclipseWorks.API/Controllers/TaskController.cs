using AutoMapper;
using EclipseWorks.Core.Models;
using EclipseWorks.DTO.BaseDTO;
using EclipseWorks.DTO.Task;
using EclipseWorks.Services;
using EclipseWorks.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorks.API.Controllers
{
    public class TaskController(
          ITaskService taskService,
          IMapper mapper) : CustomBaseController
    {
        private readonly ITaskService _taskService = taskService;
        private readonly IMapper _mapper = mapper;

        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetAllByProject(long projectId, CancellationToken ct)
        {
            var result = _mapper.Map<List<TaskListingDTO>>(await _taskService.GetAllByProjectAsync(projectId, ct));

            if (result == null)
                return NotFound(new APIResponseDTO<List<TaskListingDTO>>());

            return Ok(new APIResponseDTO<List<TaskListingDTO>> { Success = true, Data = result });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskRegistrationDTO obj, CancellationToken ct)
        {
            if (obj == null)
                return BadRequest(new APIResponseDTO<TaskRegistrationDTO>());

            await _taskService.AddAsync(_mapper.Map<TaskModel>(obj), ct);
            return Ok(new APIResponseDTO<TaskRegistrationDTO> { Success = true });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TaskEditDTO obj, CancellationToken ct)
        {
            if (obj == null)
                return BadRequest(new APIResponseDTO<TaskEditDTO>());

            await _taskService.UpdateAsync(_mapper.Map<TaskModel>(obj), ct);
            return Ok(new APIResponseDTO<TaskEditDTO> { Success = true });
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus([FromBody] TaskEditStatusDTO obj, CancellationToken ct)
        {
            if (obj == null)
                return BadRequest(new APIResponseDTO<TaskEditStatusDTO>());

            await _taskService.UpdateStatusAsync(_mapper.Map<TaskModel>(obj), ct);
            return Ok(new APIResponseDTO<TaskEditStatusDTO> { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id, CancellationToken ct)
        {
            var result = await _taskService.DeleteByIdAsync(id, ct);
            return Ok(new APIResponseDTO { Success = result });
        }
    }
}