using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Services;
namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            var students = _studentService.GetStudents();
            return View(students);
        }
    }
}
