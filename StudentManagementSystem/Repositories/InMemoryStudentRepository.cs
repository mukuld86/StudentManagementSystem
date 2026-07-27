using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories
{
    public class InMemoryStudentRepository : IStudentRepository
    {
        private readonly List<Student> _students;
        public InMemoryStudentRepository()
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
        public List<Student> GetAll()
        {
            return _students;
        }
        public void Add(Student student)
        {
            int maxId = 0;
            foreach(var existingStudent in _students)
            {
                if (existingStudent.Id > maxId)
                {
                    maxId = existingStudent.Id;
                }
            }
            student.Id = maxId+1;
            _students.Add(student);
        }



        public Student? GetById(int id)
        {
            foreach(var student in _students)
            {
                if(student.Id== id)
                {
                    return student;
                }
            }
            return null;
        }

        public bool Update(Student student)
        {
            foreach(var existingStudent in _students)
            {
                if(existingStudent.Id == student.Id)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.Course = student.Course;
                    existingStudent.Age = student.Age;
                    existingStudent.Email = student.Email;
                    return true;

                }
            }
            return false;
        }
        public bool Delete(int id)
        {
            Student? student = GetById(id);
            if (student == null)
            {
                return false;
            }
            _students.Remove(student);
            return true;
        }
    }
}
