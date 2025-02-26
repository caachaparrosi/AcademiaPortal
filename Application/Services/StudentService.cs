using Core.DTOs;
using Core.Interfaces;
using Core.Models;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IProgramRepository _programRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentService(IStudentRepository studentRepository, IProgramRepository programRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _programRepository = programRepository;
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.Select(s => new StudentDto 
            { 
                Id = s.Id, 
                Name = s.Name, 
                Email = s.Email,
                ProgramName = s.Program?.Name ?? "",                 
                AvailableCredits = s.AvailableCredits
            });
        }

        public async Task<StudentDto?> GetByIdAsync(Guid id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student == null ? null : new StudentDto 
            { 
                Id = student.Id, 
                Name = student.Name, 
                Email = student.Email,
                ProgramName = student.Program?.Name ?? "", 
                AvailableCredits = student.AvailableCredits 
            };
        }

        public async Task<StudentDto> CreateAsync(CreateStudentDto studentDto)
        {
            if (await _studentRepository.ExistsAsync(studentDto.Email))
                throw new Exception("El email ya está registrado.");

            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = studentDto.Name,
                Email = studentDto.Email
            };

            student = await _studentRepository.AddAsync(student);
            return new StudentDto { Id = student.Id, Name = student.Name, Email = student.Email };
        }

        public async Task<StudentDto> AssignProgramAsync(AssignProgramDto assignProgramDto)
        {
            var student = await _studentRepository.GetByIdAsync(assignProgramDto.StudentId);
            if (student == null)
                throw new Exception("El estudiante no existe.");

            var program = await _programRepository.GetByIdAsync(assignProgramDto.ProgramId);
            if (program == null)
                throw new Exception("El programa seleccionado no existe.");

            student.ProgramId = assignProgramDto.ProgramId;
            student.AvailableCredits = program.TotalCredits;

            await _studentRepository.UpdateAsync(student);

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                ProgramName = student.Program?.Name ?? "",
                AvailableCredits = student.AvailableCredits
            };
        }


        public async Task<StudentDto> AddCoursesToStudentAsync(SelectCoursesDto selectCoursesDto)
        {
            var student = await _studentRepository.GetByIdAsync(selectCoursesDto.StudentId);
            if (student == null)
                throw new Exception("El estudiante no existe.");

            if (selectCoursesDto.CourseIds.Count > 3)
                throw new Exception("Un estudiante solo puede inscribirse en un máximo de 3 materias.");

            var selectedCourses = await _courseRepository.GetByIdsAsync(selectCoursesDto.CourseIds);
            if (selectedCourses.Count != selectCoursesDto.CourseIds.Count)
                throw new Exception("Una o más materias no existen.");

            // Calcular el total de créditos necesarios sumando los créditos de cada curso
            var totalCreditsNeeded = selectedCourses.Sum(course => course.Credits);
            if (student.AvailableCredits < totalCreditsNeeded)
                throw new Exception($"No tienes suficientes créditos. Te quedan {student.AvailableCredits} y necesitas {totalCreditsNeeded}.");

            var uniqueTeachers = selectedCourses.Select(c => c.TeacherId).Distinct().Count();
            if (uniqueTeachers < selectedCourses.Count())
                throw new Exception("No puedes seleccionar materias con el mismo profesor.");

            student.Courses = selectedCourses;
            student.AvailableCredits -= totalCreditsNeeded;

            await _studentRepository.UpdateAsync(student);

            var courseDtos = selectedCourses.Select(course => new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Credits = course.Credits,
                TeacherName = course.Teacher.Name
            }).ToList();

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                ProgramName = student.Program?.Name ?? "",
                AvailableCredits = student.AvailableCredits,
                Courses = courseDtos
            };
        }

    }
}
