using AutoMapper;
using EclipseWorks.Core.Models;
using EclipseWorks.DTO.BaseDTO;
using EclipseWorks.DTO.Task;
using EclipseWorks.DTO.TaskComment;
using EclipseWorks.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorks.API.Controllers
{
    public class TaskCommentController(
          ITaskCommentService taskCommentService,
          IMapper mapper) : CustomBaseController
    {
        private readonly ITaskCommentService _taskCommentService = taskCommentService;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskCommentRegistrationDTO obj, CancellationToken ct)
        {
            if (obj == null)
                return BadRequest(new APIResponseDTO<TaskCommentRegistrationDTO>());

            await _taskCommentService.AddAsync(_mapper.Map<TaskCommentModel>(obj), ct);
            return Ok(new APIResponseDTO<TaskCommentRegistrationDTO> { Success = true });
        }
    }
}