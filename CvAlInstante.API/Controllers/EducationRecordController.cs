using CvAlInstante.Application.Contract;
using CvAlInstante.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CvAlInstante.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EducationRecordController : ControllerBase
{
    private readonly IEducationRecordService _educationService;

    public EducationRecordController(IEducationRecordService educationService)
    {
        _educationService = educationService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EducationRecordDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _educationService.CreateAsync(dto);

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result.Data);
    }

    [HttpGet("resume/{resumeId}")]
    public async Task<IActionResult> GetByResume(int resumeId)
    {
        var result = await _educationService.GetByResumeAsync(resumeId);
        return Ok(result.Data);
    }
}
