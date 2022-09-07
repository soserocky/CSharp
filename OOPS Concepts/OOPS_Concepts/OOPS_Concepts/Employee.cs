using System;
using System.Collections.Generic;

namespace OOPS_Concepts
{
    public class Employee : IComparable<Employee>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int Marks { get; set; }

        public int CompareTo(Employee other)
        {
            if (this.Marks == other.Marks)
                return 0;

            return this.Marks > other.Marks ? 1 : -1;
        }
    }
}