using StudentManagementSystem.Models;

namespace StudentManagementSystem.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student? GetByRegistrationNumber(int registrationNumber);
        void Add(Student student);
        bool Update(Student student);
        bool Delete(int registrationNumber);
        Student? Search(int? registrationNumber, string? email);
    }
}
