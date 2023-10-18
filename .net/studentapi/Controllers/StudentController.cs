using Microsoft.AspNetCore.Mvc;

namespace studentapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students = new List<Student>()
{
            new Student { Id = 1, FirstName = "Paul", LastName = "Ochon", Birthdate = new DateTime(1950, 12, 1) },
new Student { Id = 2, FirstName = "Daisy", LastName = "Drathey", Birthdate = new DateTime(1970, 12, 1) },
new Student { Id = 3, FirstName = "Elie", LastName = "Coptaire", Birthdate = new DateTime(1980, 12, 1) }

};


        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStudents")]
        public IActionResult Get()
        {
            if(_students.Count()==0)
            {
                return NoContent();
            }
            return Ok(_students);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Student student = _students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();

            }
            return Ok(student);
        }
        [HttpPost]
        public IActionResult addOne(Student student)
        {
            if (_students.Any(x => x.Id == student.Id))
            {
                return Conflict("id already exists");
            }

            _students.Add(student);
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public IActionResult deleteOne(int id)
        {
            Student deletedStudent = _students.FirstOrDefault(x => x.Id == id);
            if (deletedStudent == null)
            {
                return NotFound();
               
            }
            _students.Remove(deletedStudent);
            return Ok(deletedStudent);
        }
    }
}