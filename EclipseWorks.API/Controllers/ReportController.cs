using AutoMapper;
using EclipseWorks.DTO.BaseDTO;
using EclipseWorks.DTO.Report;
using EclipseWorks.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorks.API.Controllers
{
    public class ReportController(
          ITaskService taskService,
          IMapper mapper) : CustomBaseController
    {
        private readonly ITaskService _taskService = taskService;
        private readonly IMapper _mapper = mapper;

        [HttpGet("performancelast30days/{applicantUserId}")]
        public async Task<IActionResult> GetPerformanceLast30Days(long applicantUserId, CancellationToken ct)
        {
            var result = _mapper.Map<List<TaskListingPerformanceLast30DaysDTO>>(await _taskService.GetPerformanceLast30Days(applicantUserId, ct));

            if (result == null)
                return NotFound(new APIResponseDTO<List<TaskListingPerformanceLast30DaysDTO>>());

            return Ok(new APIResponseDTO<List<TaskListingPerformanceLast30DaysDTO>> { Success = true, Data = result });
        }
    }
}