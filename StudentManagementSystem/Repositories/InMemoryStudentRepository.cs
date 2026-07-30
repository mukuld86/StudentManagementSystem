using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories
{
    public class InMemoryStudentRepository 
    {
        private readonly List<Student> _students;
        public InMemoryStudentRepository()
        {
            _students = new List<Student>
            {
                 new Student
                {
                    RegistrationNumber = 1,
                    Name = "Mukul",
                    Course = "CSE",
                    Age = 22,
                    Email = "mukul@gmail.com"
                },
                new Student
                {
                    RegistrationNumber = 2,
                    Name = "Rahul",
                    Course = "IT",
                    Age = 21,
                    Email = "rahul@gmail.com"
                },
                new Student
                {
                    RegistrationNumber = 3,
                    Name = "Priya",
                    Course = "ECE",
                    Age = 23,
                    Email = "priya@gmail.com"
                },
                new Student
                {
                    RegistrationNumber = 4,
                    Name = "Neha",
                    Course = "AI",
                    Age = 20,
                    Email = "neha@gmail.com"
                },
                new Student
                {
                    RegistrationNumber = 5,
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
                if (existingStudent.RegistrationNumber > maxId)
                {
                    maxId = existingStudent.RegistrationNumber;
                }
            }
            student.RegistrationNumber = maxId+1;
            _students.Add(student);
        }



        public Student? GetById(int id)
        {
            foreach(var student in _students)
            {
                if(student.RegistrationNumber== id)
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
                if(existingStudent.RegistrationNumber == student.RegistrationNumber)
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
