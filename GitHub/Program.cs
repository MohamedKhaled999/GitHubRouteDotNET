using System.ComponentModel;

namespace GitHub
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");

            //please note there are some of implementation in sparate files

            #region Q1:Define a struct "Person" with propertie "Name" and "Age".Create an array of three"Person" objects and populate it with C# program to display the details of all the persons in the array

            Person[] people =
                                {
                                new Person(){Name="Ahmed",Age=30},
                                new Person(){Name = "Mohamed " ,Age =24 },
                                new Person(){Name = "Ali " ,Age =22 }
                                };
            Console.WriteLine("----------------------Q1-----------------------");
            foreach (Person person in people)
            {
                Console.WriteLine($"Name is :{person.Name,-20} Age is :{person.Age}");
            }


            #endregion


            #region Q2:Create a struct called "Point" to represent a 2D point with properties "X" and "Y". Write a C# program that takes two points as input from the user and calculates the distance between them.

            Console.WriteLine("---------------------------Q2---------------------");

            int x, y;
            bool check1, check2;
            do
            {
               
            Console.WriteLine("Plese enter P1  x");
               check1= int.TryParse(Console.ReadLine(), out x);
            Console.WriteLine("Plese enter P1  y");
               check2= int.TryParse(Console.ReadLine(), out y);
            }
            while (!check1||!check2);
            Point point1 = new Point(x,y);

            do
            {

                Console.WriteLine("Plese enter P2  x");
                check1 = int.TryParse(Console.ReadLine(), out x);
                Console.WriteLine("Plese enter P2  y");
                check2 = int.TryParse(Console.ReadLine(), out y);
            }
            while (!check1 || !check2);
            Point point2 = new Point(x, y);

            // implementation of CalDistance in Point Struct 

            Console.WriteLine($"The Distance Between {point1} and {point2} is : {point1.calDistance(point2)}");

            #endregion

            #region Q3:Create a struct called "Person" with properties "Name" and "Age". Write a C# program that takes details of 3 persons as input from the user and displays the name and age of the oldest person.
            Person[] people1 = new Person[3];
            int age;
            string name="";
            bool ch1;
            int i = 0;
            Console.WriteLine("--------------------------Q3------------------------");



            do
            {
                Console.WriteLine($"Plese enter age for person {i+1} :");
                ch1 = int.TryParse(Console.ReadLine(), out age);
                Console.WriteLine($"Plese enter name for person {i+1} : ");
                name= Console.ReadLine();

                people1[i] = new() { Name = name, Age = age };
            }
            while (!ch1 || name=="" || ++i<3);

            int oldest = 0;
            for (int j =1; j < people1.Length; j++)
            {
                if (people1[j].Age > people1[oldest].Age)
                    oldest = j;
            }

            Console.WriteLine($"the oldest person is : {people1[oldest].Name}   {people1[oldest].Age}");
            #endregion
        }
    }
}
