using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Interfaces;

namespace StudentManagementSystem.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context= context;
        }
        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }
        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public bool Delete(int registrationNumber)
        {
            var student = _context.Students.Find(registrationNumber);
            if (student == null)
            {
                return false;
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }


        public Student? GetByRegistrationNumber(int registrationNumber)
        {
            return _context.Students.Find(registrationNumber);
        }

        public bool Update(Student student)
        {
            var existingStudent = _context.Students.Find(student.RegistrationNumber);
            if (existingStudent == null)
            {
                return false;
            }
            existingStudent.Name = student.Name;
            existingStudent.Course = student.Course;
            existingStudent.Age = student.Age;
            existingStudent.Email = student.Email;
            _context.SaveChanges();
            return true;
        }
        public Student? Search(int? registrationNumber, string? email)
        {
            return _context.Students.FirstOrDefault(s =>
            (registrationNumber.HasValue && s.RegistrationNumber == registrationNumber)
                ||
                (!string.IsNullOrWhiteSpace(email) && email == s.Email));
        }
    }
}
