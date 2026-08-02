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
        public List<Student> Search(SearchRequest request)
        {
            IQueryable<Student> query = _context.Students;

            if (request.RegistrationNumber.HasValue)
            {
                query = query.Where(s =>
                    s.RegistrationNumber == request.RegistrationNumber);
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                query = query.Where(s =>
                    s.Email == request.Email);
            }

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(s =>
                    s.Name.Contains(request.Name));
            }

            switch (request.SortBy)
            {
                case "NameAsc":
                    query = query.OrderBy(s => s.Name);
                    break;

                case "NameDesc":
                    query = query.OrderByDescending(s => s.Name);
                    break;

                case "AgeAsc":
                    query = query.OrderBy(s => s.Age);
                    break;

                case "AgeDesc":
                    query = query.OrderByDescending(s => s.Age);
                    break;

                case "RegAsc":
                    query = query.OrderBy(s => s.RegistrationNumber);
                    break;

                case "RegDesc":
                    query = query.OrderByDescending(s => s.RegistrationNumber);
                    break;

                default:
                    query = query.OrderBy(s => s.RegistrationNumber);
                    break;
            }
            return query.ToList();
        }
    }
}
