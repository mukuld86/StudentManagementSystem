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
        public IActionResult Details(int registrationNumber)
        {
            Student? student = _studentService.GetByRegistrationNumber(registrationNumber);
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
        public IActionResult Edit(int registrationNumber)
        {
            var student = _studentService.GetByRegistrationNumber(registrationNumber);
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
        public IActionResult Delete(int registrationNumber)
        {
            var student = _studentService.GetByRegistrationNumber(registrationNumber);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            bool deleted = _studentService.DeleteStudent(student.RegistrationNumber);
            if (!deleted)
            {
                return NotFound();
            }
            TempData["SuccessMessage"] = "Student deleted Successfully";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Search()
        {
            return View(new SearchRequest());
        }
        [HttpPost]
        public IActionResult Search(SearchRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            if (!request.RegistrationNumber.HasValue &&
                string.IsNullOrWhiteSpace(request.Email) &&
                string.IsNullOrWhiteSpace(request.Name))
            {
                ModelState.AddModelError("", "Please enter at least one search criterion.");

                return View(request);
            }

            request.Results = _studentService.Search(request);
            return View(request);

        }
    }
}
