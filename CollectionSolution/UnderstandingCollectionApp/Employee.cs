﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingCollectionApp
{
    public class Employee:IEquatable<Employee>,IComparable<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee()
        {
            
        }
        public Employee(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public bool Equals(Employee? other)
        {
            if (this.Id == other.Id && this.Name == other.Name)
                return true;
            return true;

        }

        public override string ToString()
        {
            return Id+" "+Name+" "+Salary;  
        }

        public int CompareTo(Employee? other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
