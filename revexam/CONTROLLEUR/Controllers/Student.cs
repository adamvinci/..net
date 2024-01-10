using Microsoft.AspNetCore.Mvc;
using CONTROLLEUR.model;
namespace CONTROLLEUR.Controllers
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

        private readonly ILogger<Student> _logger;

        public StudentControlleur(ILogger<Student> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IList<Student> Get()
        {
            return _students;
        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetOne(int id)
        {
            Student student = _students.FirstOrDefault((s)=>s.Id== id);
            if (student == null) return NotFound();
            return Ok(student);
        }
        [HttpPost]
        public ActionResult<Student> Post(Student student)
        {
            if(_students.Contains(student)||(_students.FirstOrDefault(s=>s.Id==student.Id)!=null)) return Conflict();
            _students.Add(student);
            return student;
        }
    }
}