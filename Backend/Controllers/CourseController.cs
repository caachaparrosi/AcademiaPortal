using Core.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseDto courseDto)
        {
            try
            {
                var course = await _courseService.CreateAsync(courseDto);
                return CreatedAtAction(nameof(GetAll), new { id = course.Id }, course);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
