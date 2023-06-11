using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    internal class Person
    {
        /// <summary>
        /// Field that holds name
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Gets the student name
        /// </summary>
        public string Name { get { return _name; } }

        /// <summary>
        /// Constructs Student object
        /// </summary>
        /// <param name="name">Name of student</param>
        /// <param name="gpa">Grade Point Average</param>
        internal Person(string name)
        {
            _name = name;
        }

        public override string ToString() { return _name; }
    }
}
