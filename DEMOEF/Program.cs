using DEMOEF.models;
using DEMOEF04.DataSeeding;
using Microsoft.EntityFrameworkCore;

namespace DEMOEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using CompanyDBContext db = new CompanyDBContext();

            #region Data Seed
            CompanyDbContextSeed.Seed(db);
            #endregion

            #region Nav. Properties
            #region EX1
            //var employee = (from E in db.Employees
            //                where E.Code == 1
            //                select E
            //               ).FirstOrDefault();
            //Console.WriteLine($"Employee Name is :{employee?.Name} ,Department {employee.Department?.Name ?? "No Data"}");
            #endregion

            #region EX2
            //var department = (from D in db.Departments
            //                where D.DeptId == 10
            //                select D
            //               ).FirstOrDefault();
            //if (department != null)
            //{
            //    Console.WriteLine($"Department Id is :{department.DeptId} ,Department Name is :{department.Name} ");

            //    foreach(var e in department.Employees)
            //    {
            //        Console.WriteLine($"Employee Code: {e.Code} Employee Name is : {e.Name}");

            //    }
            //}
            #endregion

            #endregion

            #region Explict Loading
            #region EX1
            //var employee = (from E in db.Employees
            //                where E.Code == 3
            //                select E
            //               ).FirstOrDefault();
            //if (employee != null)
            //{
            //    db.Entry<Employee>(employee).Reference(nameof(Employee.Department)).Load();
            //Console.WriteLine($"Employee Name is :{employee.Name} ,Department {employee.Department?.Name??"No Data"}");
            //}

            #endregion

            #region EX2
            //var department = (from D in db.Departments
            //                  where D.DeptId == 10
            //                  select D
            //               ).FirstOrDefault();
            //if (department != null)
            //{
            //    db.Entry(department).Collection(d=>d.Employees).Load();
            //    Console.WriteLine($"Department Id is :{department.DeptId} ,Department Name is :{department.Name} ");

            //    foreach (var e in department.Employees)
            //    {
            //        Console.WriteLine($"Employee Code: {e.Code} Employee Name is : {e.Name}");

            //    }
            //}
            #endregion


            #endregion

            #region Eager Loading

            #region EX1
            //var employee = (from E in db.Employees.Include(e=>e.Department)
            //                where E.Code == 3
            //                select E
            //               ).FirstOrDefault();
            //if (employee != null)
            //{

            //    Console.WriteLine($"Employee Name is :{employee.Name} ,Department {employee.Department?.Name ?? "No Data"}");
            //}

            #endregion

            #region EX2

            //var department = (from D in db.Departments.Include(D=>D.Employees)
            //                  where D.DeptId == 10
            //                  select D
            //               ).FirstOrDefault();
            //if (department != null)
            //{
            //    Console.WriteLine($"Department Id is :{department.DeptId} ,Department Name is :{department.Name} ");

            //    foreach (var e in department.Employees)
            //    {
            //        Console.WriteLine($"Employee Code: {e.Code} Employee Name is : {e.Name}");

            //    }
            //}
            #endregion


            #endregion

            #region Lazy Loading

            #region EX1
            var employee = (from E in db.Employees
                            where E.Code == 3
                            select E
                           ).FirstOrDefault();
            if (employee != null)
            {

                Console.WriteLine($"Employee Name is :{employee.Name} ,Department {employee.Department?.Name ?? "No Data"}");
            }

            #endregion

            #region EX2

            var department = (from D in db.Departments
                              where D.DeptId == 10
                              select D
                           ).FirstOrDefault();
            if (department != null)
            {
                Console.WriteLine($"Department Id is :{department.DeptId} ,Department Name is :{department.Name} ");

                foreach (var e in department.Employees)
                {
                    Console.WriteLine($"Employee Code: {e.Code} Employee Name is : {e.Name}");

                }
            }
            #endregion


            #endregion



        }
    }
}
