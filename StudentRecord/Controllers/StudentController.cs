using Microsoft.AspNetCore.Mvc;

namespace StudentRecord.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
