using GitHub.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public  SecurityLevel  Security { get; set; }

        public Gender Gender { get; set; }
        public HireDate HireDate { get; set; }=new(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

        public Employee(int id, string name, double salary, SecurityLevel security, Gender gender)
        {
            Id = id;
            Name = name;
            Salary = salary;
            Security = security;
            Gender = gender;
        }

        public Employee(int id, string name, double salary, Gender gender)
        {
            Id = id;
            Name = name;
            Salary = salary;
            Gender = gender;
        }

        public override string ToString()
        {


            return @$"----------------------------------------------------------------
|{Id} | {Name} | {Gender} | {Salary:C} | {Security} | {HireDate} |
----------------------------------------------------------------";
        }







    }
}
