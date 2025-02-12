using DEMOEF.models;

namespace DEMOEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            CompanyDBContext db = new CompanyDBContext();

            #region CRUD
            #region Create/Insert
            //Employee employee = new Employee()
            //{ 
            //    EmpName="Mohamed Khaled"
            //    ,Age=11,
            //    EmailAddress="mo@mo.com",
            //    Password="122"
            //    ,PhoneNumber="1233"
            //    ,Salary=25555.55M
            //};
            //Console.WriteLine(db.Entry<Employee>(employee).State);

            //db.Employees.Add(employee);
            //db.Add(employee); //Local
            //Console.WriteLine(db.Entry<Employee>(employee).State);

            //db.Set<Employee>().Add(employee);
            //db.SaveChanges();
            #endregion
            #region Read
            //var emps = (from e in db.Employees
            //           where e.Code == 5 
            //           select e).FirstOrDefault();

            //if (emps is not null)
            //{
            //    Console.WriteLine(db.Entry<Employee>(emps).State);
            //}
            #endregion
            #region Update

            //var emp2 = (from e in db.Employees
            //            where e.Code == 7
            //            select e).FirstOrDefault();


            //if (emp2 is not null)
            //{
            //    Console.WriteLine(db.Entry<Employee>(emp2).State);
            //    emp2.EmpName = "Nade";
            //    Console.WriteLine(db.Entry<Employee>(emp2).State);
            //    db.SaveChanges();
            //}

            #endregion
            #region Delete

            //var emp3 = (from e in db.Employees
            //            where e.Code == 7
            //            select e).FirstOrDefault();

            //var emp3 = (from e in db.Employees
            //            where e.Code == 7
            //            select e).FirstOrDefault();

            //if (emp3 is not null)
            //{

            //    Console.WriteLine(db.Entry<Employee>(emp3).State);
            //    db.Remove(emp3);
            //    Console.WriteLine(db.Entry<Employee>(emp3).State);
            //    db.SaveChanges();
            //    Console.WriteLine(db.Entry<Employee>(emp3).State);

            //}

            #endregion


            #endregion

            #region TPCC

            using var dbContext = new CompanyDBContext();

            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee()
            {
                Name = "Rana",
                Address = "Banha",
                Age = 22,
                Salary = 4000,
                StartDate = DateTime.Now,
            };

            PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
            {
                Name = "Nada",
                Address = "Banha",
                Age = 22,
                CountOfHours = 20
                ,HourRate=2.5M
            };

            //dbContext.FullTimeEmployees.Add(fullTimeEmployee);
            //dbContext.partTimeEmployees.Add(partTimeEmployee);
            //dbContext.SaveChanges();


            var FTEmployee = from FTE in dbContext.FullTimeEmployees
                             select FTE;
            var PTEmployee = from PTE in dbContext.partTimeEmployees
                             select PTE;

            foreach (var employee in FTEmployee)
            {
                Console.WriteLine($"{employee.Name} -- {employee.Salary}");
            }

            Console.WriteLine("---");

            foreach (var employee in PTEmployee)
            {
                Console.WriteLine($"{employee.Name} -- {employee.HourRate}");
            }

            #endregion

            #region TPH
            FullTimeEmployee fullTimeEmployee1 = new FullTimeEmployee()
            {
                Name = "khaled",
                Address = "ahmed",
                Age = 24,
                Salary = 4000,
                StartDate = DateTime.Now,
            };

            PartTimeEmployee partTimeEmployee2 = new PartTimeEmployee()
            {
                Name = "mohamed",
                Address = "khaled",
                Age = 25,
                CountOfHours = 100
                ,
                HourRate = 2.5M
            };

            //dbContext.FullTimeEmployees.Add(fullTimeEmployee1);
            //dbContext.partTimeEmployees.Add(partTimeEmployee2);
            //dbContext.SaveChanges();


            //var FTEmployee2 = from FTE in dbContext.FullTimeEmployees
            //                 select FTE;
            //var PTEmployee2 = from PTE in dbContext.partTimeEmployees
            //                 select PTE;

            //foreach (var employee in FTEmployee2)
            //{
            //    Console.WriteLine($"{employee.Name} -- {employee.Salary}");
            //}

            //Console.WriteLine("---");

            //foreach (var employee in PTEmployee2)
            //{
            //    Console.WriteLine($"{employee.Name} -- {employee.HourRate}");
            //}



            /*another way
            /*
            */

            var Employee2 = from PTE in dbContext.Employee2s
                              select PTE;

            foreach (var employee in Employee2.OfType<FullTimeEmployee>())
            {
                Console.WriteLine($"{employee.Name} -- {employee.Salary}");
            }

            Console.WriteLine("---");

            foreach (var employee in Employee2.OfType<PartTimeEmployee>())
            {
                Console.WriteLine($"{employee.Name} -- {employee.HourRate}");
            }




            #endregion


        }
    }
}
