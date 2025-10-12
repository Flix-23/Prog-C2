using HospitalApi.dtos.Requests;
using HospitalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resp = await _service.GetAllAsync();
            return resp.Success ? Ok(resp) : BadRequest(resp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resp = await _service.GetByIdAsync(id);
            return resp.Success ? Ok(resp) : NotFound(resp);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientRequest req)
        {
            var resp = await _service.CreateAsync(req);
            return resp.Success ? CreatedAtAction(nameof(GetById), new { id = resp.Data.Id }, resp) : BadRequest(resp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PatientRequest req)
        {
            var resp = await _service.UpdateAsync(id, req);
            return resp.Success ? NoContent() : BadRequest(resp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resp = await _service.DeleteAsync(id);
            return resp.Success ? NoContent() : NotFound(resp);
        }
    }

}
