using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            _studentLogic = studentLogic;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _studentLogic.GetStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentLogic.GetStudentById(id);

            if (student == null)
            {
                return NotFound(); // 404 
            }

            return Ok(student);
        }

        [HttpPost]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult PostStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest(); // 400
            }

            _studentLogic.InsertStudents(student);

            return Ok(student); // 200 
        }

        // Ejercicio 6
        [HttpGet]
        public IActionResult GetStudents([FromQuery] int? age = null)
        {
            IEnumerable<Student> students = _studentLogic.GetStudentsByAge();

            if (!age.HasValue)
            {
                return BadRequest();
            }

            students = students.Where(s => s.Age == age);
            return Ok(students); // 200 
        }
    }
}
