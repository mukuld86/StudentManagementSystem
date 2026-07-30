using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        
        public List<Student> GetStudents()
        {
            return _repository.GetAll();
        }
        public Student? GetByRegistrationNumber(int registrationNumber)
        {
            return _repository.GetByRegistrationNumber(registrationNumber);
        }
        public void AddStudent(Student student)
        {
            _repository.Add(student);
        }
        public bool UpdateStudent(Student student)
        {
            return _repository.Update(student);

        }
        public bool DeleteStudent(int registrationNumber)
        {
            return _repository.Delete(registrationNumber);
        }
    }
}
