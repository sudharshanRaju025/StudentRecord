using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using StudentRecord.Data;
using StudentRecord.Models;
using StudentRecord.Models.Entities;

namespace StudentRecord.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                subscribed = viewModel.subscribed
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return View(); 
        }


    }
}
