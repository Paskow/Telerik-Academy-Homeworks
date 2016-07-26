using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    public class Student
    {
        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.ID = id;

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be an empty string");
                }
                this.name = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            private set
            {
                if (value <= 10000 || value >= 99999)
                {
                    throw new ArgumentException("ID must be between 10000 and 99999");
                }       

                this.id = value;

            }
        }
    }
}
