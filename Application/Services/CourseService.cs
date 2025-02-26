using Core.DTOs;
using Core.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;

        public CourseService(ICourseRepository courseRepository, ITeacherRepository teacherRepository)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Name = c.Name,
                Credits = c.Credits,
                TeacherName = c.Teacher.Name
            });
        }

        public async Task<CourseDto?> GetByIdAsync(Guid id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            return course == null ? null : new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Credits = course.Credits,
                TeacherName = course.Teacher.Name
            };
        }

        public async Task<CourseDto> CreateAsync(CreateCourseDto courseDto)
        {
            if (await _courseRepository.ExistsAsync(courseDto.Name))
                throw new Exception("La materia ya existe.");

            var teacher = await _teacherRepository.GetByIdAsync(courseDto.TeacherId);
            if (teacher == null)
                throw new Exception("El profesor no existe.");

            var course = new Course
            {
                Id = Guid.NewGuid(),
                Name = courseDto.Name,
                TeacherId = courseDto.TeacherId
            };

            course = await _courseRepository.AddAsync(course);

            return new CourseDto { Id = course.Id, Name = course.Name, Credits = course.Credits, TeacherName = teacher.Name };
        }
    }
}
