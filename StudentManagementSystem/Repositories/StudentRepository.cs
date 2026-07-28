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

        public bool Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return false;
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }


        public Student? GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public bool Update(Student student)
        {
            var existingStudent = _context.Students.Find(student.Id);
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
    }
}
