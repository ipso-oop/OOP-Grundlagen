using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung251
{
   
    
    /// <summary>
    /// Vorlesung & Student als Aggregtion
    /// </summary>
    public class Student
    {
      
        private string _Name;

        public Student(string name)
        {
            _Name = name;
        }

        string Name
        {
            get { return _Name; }
        }
    }


    public class Vorlesung
    {

        private Student _Student;

        public Vorlesung(Student student)
        {
            _Student = student;
        }

        Student Student
        {
            get { return _Student; }
        }
    }
}
