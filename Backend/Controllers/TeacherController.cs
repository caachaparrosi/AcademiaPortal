using Core.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _teacherService.GetAllAsync();
            return Ok(teachers);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTeacherDto teacherDto)
        {
            try
            {
                var teacher = await _teacherService.CreateAsync(teacherDto);
                return CreatedAtAction(nameof(GetAll), new { id = teacher.Id }, teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
