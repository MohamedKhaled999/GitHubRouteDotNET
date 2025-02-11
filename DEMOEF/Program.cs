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
           
            


        }
    }
}
