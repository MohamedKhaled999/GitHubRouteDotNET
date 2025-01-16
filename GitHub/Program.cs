using GitHub.Enums;
using GitHub.Inheritance;

namespace GitHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region Part1/Try all what we have learned in the lecture.

            
            //Please note all implementaion in files and folders



            #endregion

            #region Part2
            //Employee employee = new Employee(1,"Mohamed Khaled Hammad",5000.500,SecurityLevel.Guest,Gender.M);

            Employee[] employees = new Employee [3]; 
            
            int i = 0;
            string? name = null;
            double sal = 0;
            Gender gen ;
            bool check=false;
            do
            {

                Console.WriteLine($"Enter Employee No.{i + 1} Name");
                name= Console.ReadLine();
                Console.WriteLine($"Enter Employee No.{i + 1} Gender");
                check = Enum.TryParse(Console.ReadLine(), out gen);
                Console.WriteLine($"Enter Employee No.{i + 1} Salary $");
                if (!check) continue;
                check =  double.TryParse(Console.ReadLine(), out sal );
                employees[i] = new(i, name, sal, gen);

            }while (!check||++i<3);

            employees[0].Security = SecurityLevel.Guest;
            employees[1].Security = SecurityLevel.DBA;
            employees[2].Security = SecurityLevel.DBA^SecurityLevel.Guest^SecurityLevel.Developer^SecurityLevel.Secretary;

            employees[0].HireDate.Month = 5;
            employees[1].HireDate.Month= 2;
            employees[2].HireDate.Month= 1;

            Console.WriteLine("Before Sorting");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }

            // I perfer using some thing like IComparable to this point , but we do't explain it yet !

            Console.WriteLine("After Sorting");


            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2-j; k++)
                {

                    if (employees[k].HireDate.Year > employees[k + 1].HireDate.Year
                    || employees[k].HireDate.Month > employees[k + 1].HireDate.Month
                    || employees[k].HireDate.Day > employees[k + 1].HireDate.Day)

                    {
                        var temp = employees[k + 1];
                        employees[k + 1] = employees[k];
                        employees[k] = temp;


                    }
                }

                


            }


            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }


            // there no need for Boxing and Unboxing in this code !

            #endregion

        }
    }



}
