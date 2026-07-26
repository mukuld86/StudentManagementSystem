using StudentManagementSystem.Models;
using System.Linq;
namespace StudentManagementSystem.Services
{
    public class StudentService
    {
        private readonly List<Student> _students;
        public StudentService()
        {
            _students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Mukul",
                    Course = "CSE",
                    Age = 22,
                    Email = "mukul@gmail.com"
                },
                new Student
                {
                    Id = 2,
                    Name = "Rahul",
                    Course = "IT",
                    Age = 21,
                    Email = "rahul@gmail.com"
                },
                new Student
                {
                    Id = 3,
                    Name = "Priya",
                    Course = "ECE",
                    Age = 23,
                    Email = "priya@gmail.com"
                },
                new Student
                {
                    Id = 4,
                    Name = "Neha",
                    Course = "AI",
                    Age = 20,
                    Email = "neha@gmail.com"
                },
                new Student
                {
                    Id = 5,
                    Name = "Ankit",
                    Course = "CSE",
                    Age = 22,
                    Email = "ankit@gmail.com"
                }
            };
        }
        public List<Student> GetStudents()
        {
            return _students;
        }
        public Student? GetStudentById(int id)
        {
            return GetStudents().FirstOrDefault(student => student.Id == id);
        }
        public void AddStudent(Student student)
        {
            int maxId = 0;
            foreach(var currStudent in _students)
            {
                if (currStudent.Id > maxId)
                    maxId = currStudent.Id;
            }
            student.Id = 1 + maxId;
            _students.Add(student);
        }
        public bool UpdateStudent(Student updatedStudent)
        {
            foreach(var student in _students)
            {
                if(student.Id == updatedStudent.Id)
                {
                    student.Name = updatedStudent.Name;
                    student.Course = updatedStudent.Course;
                    student.Age = updatedStudent.Age;
                    student.Email = updatedStudent.Email;
                    return true;
                }
            }
            return false;

        }
        public bool DeleteStudent(int id)
        {
            Student? studentToDelete = GetStudentById(id);
            if (studentToDelete == null)
            {
                return false;
            }
            _students.Remove(studentToDelete);
            return true;
        }
    }
}
