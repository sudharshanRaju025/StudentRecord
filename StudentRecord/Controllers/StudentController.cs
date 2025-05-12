using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentRecord.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentApiController : ControllerBase
    {
        // Static data of students
        private static List<Student> Students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Alice Johnson",
                Phone = "123-456-7890",
                Email = "alice@example.com",
                Subscribed = true
            },
            new Student
            {
                Id = 2,
                Name = "Bob Smith",
                Phone = "987-654-3210",
                Email = "bob@example.com",
                Subscribed = false
            },
             new Student
            {
                Id = 3,
                Name = "lakshmidhar",
                Phone = "987-654-3210",
                Email = "lakshmidhar@example.com",
                Subscribed = false
            },
              new Student
            {
                Id = 4,
                Name = "govindh",
                Phone = "987-654-3540",
                Email = "govindh@example.com",
                Subscribed = false
            }
        };

        // GET Method
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return Ok(Students);
        }

        //  GET By Id.
        public ActionResult<Student> GetById(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound(); 
            }

            return Ok(student); 
        }


        //  POST Method
        private static int NextId = 1;

        [HttpPost]
        public IActionResult Add(Student student)
        {
            student.Id = NextId++; // Simpler but less flexible
            Students.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // 🔹 PUT (Update the existing data.
        [HttpPut("{id}")]
        public IActionResult Update(int id, Student updatedStudent)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            student.Name = updatedStudent.Name;
            student.Phone = updatedStudent.Phone;
            student.Email = updatedStudent.Email;
            student.Subscribed = updatedStudent.Subscribed;

            return Ok(student);
        }

         // DELETE Method by id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            Students.Remove(student);
            return NoContent(); 
        }

        // student model
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public bool Subscribed { get; set; }
        }
    }
}
