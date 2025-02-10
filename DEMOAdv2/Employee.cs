using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOAdv2
{

    class Employee : IComparable<Employee>, IEquatable<Employee>
    {

        public Employee(int id, string name, int age, int salary)
        {
            Id = id;
            Name = name;
            Age = age;
            Salary = salary;
        }
        public Employee()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public override string ToString() =>
            $"Id = {Id}, Name = {Name} , Age = {Age} , Salary ={Salary}";
        public int CompareTo(Employee? other)
        {
            return Id.CompareTo(other.Id);
        }
        public bool Equals(Employee? other)
        {
            return Id == other.Id &&
                Name == other.Name &&
                Age == other.Age &&
                Salary == other.Salary;
            

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Age, Salary);
        }


    }

}
