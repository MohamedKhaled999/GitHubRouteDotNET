using DEMOEF.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DEMOEF04.DataSeeding
{
    internal static class CompanyDbContextSeed
    {
        public static  void Seed(CompanyDBContext companyDB)
        {
            if (companyDB is not null && !companyDB.Departments.Any()) 
            {
                var DeparmentsString = File.ReadAllText(@"DataSeeding\departments.json");
                var Departments = JsonSerializer.Deserialize<List<Department>>(DeparmentsString);

                foreach (var item in Departments)
                {
                    companyDB.Add(item);

                }
                companyDB.SaveChanges();
            }

            if (companyDB is not null && !companyDB.Employees.Any())
            {
                var EmployeesString = File.ReadAllText(@"DataSeeding\employees.json");
                var Employees = JsonSerializer.Deserialize<List<Employee>>(EmployeesString);

                foreach (var item in Employees)
                {
                    companyDB.Add(item);

                }
                companyDB.SaveChanges();
            }


        }
    }
}
