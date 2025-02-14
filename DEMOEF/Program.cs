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

            //#region EX1
            //var employee = (from E in db.Employees
            //                where E.Code == 3
            //                select E
            //               ).FirstOrDefault();
            //if (employee != null)
            //{

            //    Console.WriteLine($"Employee Name is :{employee.Name} ,Department {employee.Department?.Name ?? "No Data"}");
            //}

            //#endregion

            //#region EX2

            //var department = (from D in db.Departments
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
            //#endregion


            #endregion

            #region INNER JOIN

            //var Result = from E in db.Employees
            //             join D in db.Departments
            //             on E.DepartmentDeptId equals D.DeptId
            //             select new { DName = D.Name, EName = E.Name };

            //Result = db.Employees.Join(db.Departments,
            //                            e => e.DepartmentDeptId,
            //                            d => d.DeptId,
            //                            (E,D)=>  new { DName = D.Name, EName = E.Name });
            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"EmployeeName is {item.EName,-10}  ******      DepartmentName is {item.DName}");   
            //}


            #endregion

            #region GroupJoin
            #region EX1
            //var Result = db.Departments.GroupJoin(db.Employees,
            //    d => d.DeptId,
            //    e => e.DepartmentDeptId,
            //    (Department, Employees) => new { Department, Employees })
            //    .Where(g => g.Employees.Count() > 0);




            //Result = from d in db.Departments
            //         join e in db.Employees
            //         on d.DeptId equals e.DepartmentDeptId into grouped
            //         where grouped.Count() > 0
            //         select new { Department = d, Employees = grouped };



            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"Department is {item.Department.Name} ");
            //    foreach (var item1 in item.Employees)
            //    {
            //        Console.WriteLine($"\t\t\t{item1.Name} ");
            //    }

            //}

            #endregion

            #region EX2
            //var Result = db.Employees.GroupJoin(db.Departments,
            //e => e.DepartmentDeptId,
            //d => d.DeptId,
            //( Employee, Departments) => new { Employee, Departments })
            // .Where(g => g.Departments.Count() > 0);




            //Result = from e in db.Employees
            //         join d in db.Departments
            //         on e.DepartmentDeptId equals d.DeptId into grouped
            //         where grouped.Count() > 0
            //         select new { Employee = e, Departments = grouped };



            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"Employee is {item.Employee.Name} ");
            //    foreach (var item1 in item.Departments)
            //    {
            //        Console.WriteLine($"\t\t\t{item1.Name} ");
            //    }

            //}


            #endregion
            #endregion

            #region Left Outer Join

            #region Ex1
            //var Result = db.Departments.GroupJoin(db.Employees,
            //            D => D.DeptId,
            //            E => E.DepartmentDeptId,
            //            (Department, Employees) => new
            //            {
            //                Department,
            //                Employees = Employees.DefaultIfEmpty()
            //            })
            //    .SelectMany(X => X.Employees, (X, Employee) =>
            //                                new
            //                                {
            //                                    X.Department,
            //                                    Employee
            //                                });

            //Result = from D in db.Departments
            //         join E in db.Employees
            //         on D.DeptId equals E.DepartmentDeptId into Employees
            //         select new
            //         {
            //             Department = D,
            //             Employees = Employees.DefaultIfEmpty()
            //         } into X
            //         from Employee in X.Employees
            //         select new { X.Department, Employee };





            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"Department : {item.Department.Name}--Employee: {item.Employee.Name}");
            //}
            #endregion
            #region Ex2
            //var Result = db.Employees.GroupJoin(db.Departments,
            //            E => E.DepartmentDeptId,
            //            D => D.DeptId,
            //            (Employee,Departments ) => new
            //            {
            //                Employee,
            //                Departments = Departments.DefaultIfEmpty()
            //            })
            //    .SelectMany(X => X.Departments, (X, Department) =>
            //                                new
            //                                {
            //                                    X.Employee,
            //                                    Department
            //                                });

            //Result = from E in db.Employees
            //         join D in db.Departments
            //         on E.DepartmentDeptId equals D.DeptId into Deparments
            //         select new
            //         {
            //             Employee = E,
            //             Deparments = Deparments.DefaultIfEmpty()
            //         } into X
            //         from Department in X.Deparments
            //         select new { X.Employee, Department };





            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"Employee: {item.Employee.Name}, Department : {item.Department?.Name??"not found"}--");
            //}
            #endregion

            #endregion

            #region Cross Join
            //var Result = from E in db.Employees
            //             from D in db.Departments
            //             select new
            //             {
            //                 Employee = E,
            //                 Department = D
            //             };
            //Result = db.Employees.SelectMany(E => db.Departments.Select(D => new {
            //    Employee = E,
            //    Department = D
            //}));

            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"Employee: {item.Employee.Name} :: Department: {item.Department.Name}");
            //}
            #endregion
        }
    }
}
