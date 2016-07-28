using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsAndCourses;

namespace StudentsAndCourses.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InititializeStudent_EmptyName_ShouldThrowExpetion()
        {
            Assert.ThrowsException<ArgumentException>(() => new Student("", 23423));
        }

        [TestMethod]
        public void InititializeStudent_BiggerID_ShouldThrowExpetion()
        {
            Assert.ThrowsException<ArgumentException>(() => new Student("Pesho", 5));
        }

        [TestMethod]
        public void InititializeStudent_LowerID_ShouldThrowExpetion()
        {
            Assert.ThrowsException<ArgumentException>(() => new Student("Gosho", 432423434));
        }

        [TestMethod]
        public void AddStuddentsInSchool_ShouldAddStuddentsCorrectly()
        {
            var student1 = new Student("Pesho", 11212);
            var student2 = new Student("Gosho", 11213);
            var student3 = new Student("Mariika", 21214);
            var telerikAcademy = new School("Telerik Academy");

            telerikAcademy.AddStudentToSchool(student1);
            telerikAcademy.AddStudentToSchool(student2);
            telerikAcademy.AddStudentToSchool(student3);

            Assert.AreEqual(3, telerikAcademy.Students.Count);
        }

        [TestMethod]
        public void AddStuddentInSchool_StudentWtihSameID_ShouldThrowExpetion()
        {
            var student = new Student("Pesho", 11212);
            var telerikAcademy = new School("Telerik Academy");

            telerikAcademy.AddStudentToSchool(student);

            Assert.ThrowsException<ArgumentException>(() => telerikAcademy.AddStudentToSchool(student));
        }

        [TestMethod]
        public void AddCourseInSchool_ShouldAddCourseCorrectly()
        {
            var course = new Course("Unit testing with C#");
            var telerikAcademy = new School("Telerik Academy");

            telerikAcademy.AddCourse(course);

            Assert.AreEqual(1, telerikAcademy.Courses.Count);
        }

        [TestMethod]
        public void AddStudentInCourse_ShouldAddStudentsInCourseCorrectly()
        {
            var student1 = new Student("Pesho", 11212);
            var student2 = new Student("Gosho", 11213);
            var student3 = new Student("Mariika", 21214);
            var course = new Course("Unit testing with C#");
            var telerikAcademy = new School("Telerik Academy");

            telerikAcademy.AddStudentToSchool(student1);
            telerikAcademy.AddStudentToSchool(student2);
            telerikAcademy.AddStudentToSchool(student3);
            telerikAcademy.AddCourse(course);
            telerikAcademy.AddStudentToCourse(student1, course);
            telerikAcademy.AddStudentToCourse(student2, course);
            telerikAcademy.AddStudentToCourse(student3, course);

            Assert.AreEqual(3, telerikAcademy.Courses[0].Students.Count);
        }

        [TestMethod]
        public void AddStuddentInCourse_UnexistingCourse_ShouldThrowExeption()
        {
            var student = new Student("Mariika", 43241);
            var course = new Course("Unit testing with C#");
            var telerikAcademy = new School("Telerik Academy");

            Assert.ThrowsException<ArgumentException>(() => telerikAcademy.AddStudentToCourse(student, course));
        }
        
        [TestMethod]
        public void SchoolCoursesGetter_AddCourseThroughGetter_ShoudReturnNewCollectionAndNotAddIt()
        {
            var school = new School("Pesho");

            school.Courses.Add(new Course("dsdsd"));

            Assert.AreEqual(0, school.Courses.Count);
        }

        [TestMethod]
        public void SchoolStudentGetter_AddStudentThroughGetter_ShoudReturnNewCollectionAndNotAddIt()
        {
            var school = new School("Pesho");

            school.Students.Add(new Student("Pesho", 32331));

            Assert.AreEqual(0, school.Students.Count);
        }

        [TestMethod]
        public void AddCourse_ExistingCourse_ShouldThrowExeption()
        {
            var telerikAcademy = new School("Telerik Academy");
            var course = new Course("Unit testing with C#");

            telerikAcademy.AddCourse(course);

            Assert.ThrowsException<ArgumentException>(() => telerikAcademy.AddCourse(course));
        }

        [TestMethod]
        public void RemoveStudentFromCourse_RemoveStudent_ShouldRemoveStudentCorrectly()
        {
            var telerikAcademy = new School("Telerik Academy");
            var course = new Course("Unit testing with C#");
            var student = new Student("Mariika", 12123);

            telerikAcademy.AddStudentToSchool(student);
            telerikAcademy.AddCourse(course);
            telerikAcademy.AddStudentToCourse(student, course);
            telerikAcademy.RemoveStudentFromCourse(student, course);

            Assert.AreEqual(0, telerikAcademy.Courses[0].Students.Count);

        }

        [TestMethod]
        public void SetCourseName_UseValidName_ShouldSetItCorrectly()
        {
            var course = new Course("Unit testing with C#");

            Assert.AreEqual("Unit testing with C#", course.CourseName);
        }

        [TestMethod]
        public void InititializeCourse_UseInValidName_ShouldSetItCorrectly()
        {
            Assert.ThrowsException<ArgumentException>(() => new Course(""));
        }

        [TestMethod]
        public void RemoveStudentFromCourse_StudentWitchIsNoInThisCourse_ShouldThrowException()
        {
            var telerikAcademy = new School("Telerik Academy");
            var course = new Course("Unit testing with C#");
            var student = new Student("Mariika", 12123);

            telerikAcademy.AddStudentToSchool(student);
            telerikAcademy.AddCourse(course);


            Assert.ThrowsException<ArgumentException>(() => telerikAcademy.
                                                            RemoveStudentFromCourse(student, course));
        }

        [TestMethod]
        public void RemoveStudentFromCourse_UnExistingCourse_ShouldThrowException()
        {
            var telerikAcademy = new School("Telerik Academy");
            var course = new Course("Unit testing with C#");
            var student = new Student("Mariika", 12123);

            telerikAcademy.AddStudentToSchool(student);

            Assert.ThrowsException<ArgumentException>(() => telerikAcademy.
                                                            RemoveStudentFromCourse(student, course));
        }

        [TestMethod]
        public void AddStudentToCourse_AddExistingStudent_ShouldThrowException()
        {
            var telerikAcademy = new School("Telerik Academy");
            var course = new Course("Unit testing with C#");
            var student = new Student("Mariika", 12123);

            telerikAcademy.AddStudentToSchool(student);
            telerikAcademy.AddCourse(course);
            telerikAcademy.AddStudentToCourse(student, course);


            Assert.ThrowsException<ArgumentException>(() => telerikAcademy.
                                                            AddStudentToCourse(student, course));

        }

        [TestMethod]
        public void AddStudentToCourse_WhenCourseIsFull_ShouldThrowException()
        {
            var telerikAcademy = new School("Telerik Academy");
            var course = new Course("Unit testing with C#");
            var student = new Student("Mariika", 12123);

            telerikAcademy.AddStudentToSchool(student);
            telerikAcademy.AddCourse(course);

            for (int i = 11110; i < 11140; i++)
            {
                var newStudent = new Student("Pesho", i);
                telerikAcademy.AddStudentToSchool(newStudent);
                telerikAcademy.AddStudentToCourse(newStudent, course);
            }


            Assert.ThrowsException<ArgumentException>(() => telerikAcademy.
                                                            AddStudentToCourse(student, course));
        }
    }
}
