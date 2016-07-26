using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    public class School
    {
        private ICollection<Student> students;
        private IList<Course> courses;
        private string schoolName;

        public School(string schoolName)
        {
            this.students = new List<Student>();
            this.courses = new List<Course>();
            this.schoolName = schoolName;
        }

        public string SchoolName
        {
            get
            {
                return this.schoolName;
            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public IList<Course> Courses
        {
            get
            {
                return new List<Course>(this.courses);
            }
        }

        public void AddStudentToSchool(Student candidate)
        {
            foreach (var student in students)
            {
                if (candidate.ID == student.ID)
                {
                    throw new ArgumentException("Student with this ID already exist in this school!");
                }
            }

            students.Add(candidate);
        }

        public void AddStudentToCourse(Student candidate, Course course)
        {
            if (students.Contains(candidate) && courses.Contains(course))
            {
                courses[courses.IndexOf(course)].AddStudent(candidate);
            }
            else
            {
                throw new ArgumentException("Student or course do not exist in this school");
            }
            
        }

        public void RemoveStudentFromCourse(Student candidate, Course course)
        {
            if (Courses.Contains(course))
            {
                courses[courses.IndexOf(course)].RemoveStudent(candidate);
            }
            else
            {
                throw new ArgumentException("Student or course do not exist in this school");
            }
        }

        public void AddCourse(Course course)
        {
            if (this.courses.Contains(course))
            {
                throw new ArgumentException("This course already exist!");
            }

            this.courses.Add(course);
        }
    }
}
