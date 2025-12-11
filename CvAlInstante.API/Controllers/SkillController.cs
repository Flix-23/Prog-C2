using CvAlInstante.Application.Contract;
using CvAlInstante.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CvAlInstante.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillController : ControllerBase
{
    private readonly ISkillService _skillService;

    public SkillController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SkillDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _skillService.CreateAsync(dto);

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result.Data);
    }

    [HttpGet("resume/{resumeId}")]
    public async Task<IActionResult> GetByResume(int resumeId)
    {
        var result = await _skillService.GetByResumeAsync(resumeId);
        return Ok(result.Data);
    }
}
