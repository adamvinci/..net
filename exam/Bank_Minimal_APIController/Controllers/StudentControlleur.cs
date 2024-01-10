using Microsoft.AspNetCore.Mvc;

namespace Bank_Minimal_APIController.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StudentControlleur : ControllerBase
    {
        private static List<Student> _students = new List<Student>()
{
new Student { Id = 1, FirstName = "Paul", LastName = "Ochon", Birthdate = new DateTime(1950, 12, 1) },
new Student { Id = 2, FirstName = "Daisy", LastName = "Drathey", Birthdate = new DateTime(1970, 12, 1) },
new Student { Id = 3, FirstName = "Elie", LastName = "Coptaire", Birthdate = new DateTime(1980, 12, 1) }
};


        private readonly ILogger<StudentControlleur> _logger;

        public StudentControlleur(ILogger<StudentControlleur> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetOne(int id)
        {
            Student student = _students.FirstOrDefault((c) => c.Id == id);
            if (student == null) return NotFound();
            return Ok(student);

        }

        [HttpPost]
        public ActionResult  addOne(Student newStudent)
        {
            Student student = _students.FirstOrDefault((c) => c.Id == newStudent.Id);
            if (student != null) return Conflict();
            _students.Add(newStudent);
            return Ok();
        }
    }
}