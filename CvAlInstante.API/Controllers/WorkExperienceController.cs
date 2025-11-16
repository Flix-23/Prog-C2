using CvAlInstante.Application.Contract;
using CvAlInstante.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CvAlInstante.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkExperienceController : ControllerBase
{
    private readonly IWorkExperienceService _workService;

    public WorkExperienceController(IWorkExperienceService workService)
    {
        _workService = workService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WorkExperienceDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _workService.CreateAsync(dto);

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result.Data);
    }

    [HttpGet("resume/{resumeId}")]
    public async Task<IActionResult> GetByResume(int resumeId)
    {
        var result = await _workService.GetByResumeAsync(resumeId);
        return Ok(result.Data);
    }
}
