using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    internal class Student : Person
    {
        /// <summary>
        /// Field that holds GPA
        /// </summary>
        private readonly double _gpa;

        /// <summary>
        /// Gets the GPA
        /// </summary>
        public double GPA { get { return _gpa;} }

        /// <summary>
        /// Constructs Student object
        /// </summary>
        /// <param name="name">Name of student</param>
        /// <param name="gpa">Grade Point Average</param>
        internal Student(string name, double gpa) : base(name)
        {
            _gpa = gpa;
        }

    }
}
