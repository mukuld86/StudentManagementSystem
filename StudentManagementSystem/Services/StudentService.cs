using StudentManagementSystem.Models;
namespace StudentManagementSystem.Services
{
    public class StudentService
    {
        public List<Student> GetStudents()
        {
            return new List<Student>
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
    }
}
