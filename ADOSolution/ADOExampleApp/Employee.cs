using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOExampleApp
{
    public class Employee : IEquatable<Employee>, IComparable<Employee>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Dep_Id { get; set; }
        [ForeignKey("Dep_Id")]
        public Department Department { get; set; }

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
            return Id + " " + Name + " " + Salary;
        }

        public int CompareTo(Employee? other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
