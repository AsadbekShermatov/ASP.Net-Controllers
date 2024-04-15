using ASP.Net_Controllers.Context;
using ASP.Net_Controllers.Model;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Controllers.StudentController
{
    [Route("api/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        readonly StudentContext _studentContext;    
        public StudentController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudent()
        {
            var students = _studentContext.Students;
            return Ok(students);
        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _studentContext.Students.Find(id);
            if (student != null)
            {
                return Ok(student);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public ActionResult GetStudentWithParam([FromQuery] int id)
        {
            var student = _studentContext.Students.Find(id);
            if (student != null)
            {
                return Ok(student);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult AddStudent([FromBody] Student student)
        {
            _studentContext.Students.Add(student);
            _studentContext.SaveChanges();
            return Ok();
        }
            [HttpGet]
            public ActionResult GetAction()
            {
                return RedirectToAction(nameof(GetStudent));
            }


        [HttpPut]
        public ActionResult PutStudent([FromQuery] int id, [FromBody] Student student)
        {
            var students = _studentContext.Students.Find(id);
            if (students != null)
            {
                students.Name = student.Name;
                students.Surname = student.Surname;
                students.DateOfBirh = student.DateOfBirh;
                _studentContext.Students.Update(students);
                _studentContext.SaveChanges();
                return Ok(students);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public ActionResult DeleteStudent([FromQuery] int id)
        {
            var student = _studentContext.Students.Find(id);
            if(student != null)
            {
                _studentContext.Students.Remove(student);
                _studentContext.SaveChanges();
                return Ok(student);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
