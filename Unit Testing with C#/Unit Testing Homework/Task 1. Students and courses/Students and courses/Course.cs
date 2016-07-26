using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    public class Course
    {
        private ICollection<Student> students;
        private const int maxStudents = 30;
        private string courseName;

        public Course(string courseName)
        {
            this.students = new List<Student>();
            this.CourseName = courseName;
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Course name can not be null or empty");
                }

                this.courseName = value;

            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public void AddStudent(Student candidate)
        {
            if (Students.Count >= maxStudents)
            {
                throw new ArgumentException("This course is full");
            }

            foreach (var student in Students)
            {
                if (candidate.ID == student.ID)
                {
                    throw new ArgumentException("Student with this ID already exist in this course!");
                }
            }

            this.Students.Add(candidate);
        }

        public void RemoveStudent(Student candidate)
        {
            var isStudentRemoved = false;

            foreach (var student in students)
            {
                if (candidate.ID == student.ID)
                {
                    this.students.Remove(candidate);
                    isStudentRemoved = true;
                    break;
                }
            }
            if (!isStudentRemoved)
            {
                throw new ArgumentException("There is no Student with this ID in this course!");
            }
        }
    }
}
