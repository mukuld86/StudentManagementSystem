using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
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
        public IActionResult Details(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            _studentService.AddStudent(student);
            TempData["SuccessMessage"] = "Student added successfully";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null){
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            bool updated = _studentService.UpdateStudent(student);
            if (!updated)
            {
                return NotFound();
            }
            TempData["SuccessMessage"] = "Student updated successfully";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            bool deleted = _studentService.DeleteStudent(student.Id);
            if (!deleted)
            {
                return NotFound();
            }
            TempData["SuccessMessage"] = "Student deleted Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
