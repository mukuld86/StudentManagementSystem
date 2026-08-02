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
        List<Student> Search(SearchRequest request);

    }
}
