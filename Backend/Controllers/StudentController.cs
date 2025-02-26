using Core.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto studentDto)
        {
            try
            {
                var student = await _studentService.CreateAsync(studentDto);
                return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("{studentId}/assign-program")]
        public async Task<IActionResult> AssignProgram([FromBody] AssignProgramDto assignProgramDto)
        {
            try
            {
                var student = await _studentService.AssignProgramAsync(assignProgramDto);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("{studentId}/add-courses")]
        public async Task<IActionResult> AddCoursesToStudent([FromBody] SelectCoursesDto selectCoursesDto)
        {
            try
            {
                var student = await _studentService.AddCoursesToStudentAsync(selectCoursesDto);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
