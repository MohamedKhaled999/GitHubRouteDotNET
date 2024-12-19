using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace GitHub
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region  Q1: Write a program that allows the user to enter a number then print it.

            Console.WriteLine("Please Enter A Number ");
            bool isNum =  int.TryParse(Console.ReadLine(),out int x);
            if (isNum)
            {
                Console.WriteLine($"Your Number is  : {x}");
            }
            else
            { 
                Console.WriteLine("Please Vaild Enter A Number");
            }

            #endregion

            #region Q2:Write C# program that converts a string to an integer, but the string contains non-numeric characters. And mention what will happen

            //int x2 = Convert.ToInt32("2a");
            // System.FormatException: 'The input string '2a' was not in a correct format.'

            #endregion

            #region Q3:Write C# program that Perform a simple arithmetic operation with floating-point numbers And mention what will happen
            double x3 = 0.1;
            double x33 = 0.2;

            double result = x3 + x33;

           
            Console.WriteLine($"Result of {x3} + {x33} = {result}");
            Console.WriteLine($"0.3 == result {0.3==result}"); //false
            ////there are Floating-Point Precision Issue

            #endregion

            #region Q4:Write C# program that Extract a substring from a given string.
            string x4 = "Mohamed Khaled";
            Console.WriteLine(x4.Substring(0, 7));
            #endregion

            #region Q5:Write C# program that Assigning one value type variable to another and modifying the value of one variable and mention what will happen
            int x5 = 6666;
            int x55 = x5;
            x55++;
            Console.WriteLine($"x5 = {x5} , x55 = {x55}");
            //x5 did't change 
            //x55  changed
            //because these are value types ,so they take a copy from another

            #endregion

            #region Q6:Write C# program that Assigning one reference type variable to another and modifying the object through one variable and mention what will happen
            DateTime x6 = DateTime.Now;
            DateTime x66 =x6;
            x66.AddDays(2);
            Console.WriteLine($"x6 = {x6} , x66 = {x66}");
            //seconed chaneges will applied for first one
            //because these are reference types ,so they have the same reference for one obj


            #endregion

            #region Q7:Write C# program that take two string variables and print them as one variable 
            Console.WriteLine("Plese enter 1st Str");
             var  x7 =Console.ReadLine();
            Console.WriteLine("Plese enter 2nd Str");

            var x77 =Console.ReadLine();
            Console.WriteLine("the combination is : "+x7+" "+x77);
            #endregion


            #region Q8:Write a program that calculates the simple interest given the principal amount, rate of interest, and time. The formula for simple interest is Interest = (principal * rate * time) / 100.
            Console.WriteLine("Plese enter principal");
            var principal = double.Parse(Console.ReadLine());

            Console.WriteLine("Plese enter rate ");
            var rate = double.Parse(Console.ReadLine());

            Console.WriteLine("Plese enter time  ");
            var time =double.Parse(Console.ReadLine());

            var interest = (principal * rate * time) / 100;

            Console.WriteLine($" interest = { interest:C}");


            #endregion

            #region Q9:Write a program that calculates the Body Mass Index (BMI) given a person's weight in kilograms and height in meters. The formula for BMI is BMI = (Weight) / (Height * Height)
            Console.WriteLine("Plese enter Weight ");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Plese enter Height  ");
            var height = double.Parse(Console.ReadLine());

            var bmi = (weight) / (height * height);


            Console.WriteLine($" BMI = {bmi:N3}");
            #endregion

            #region Q10:Write a program that uses the ternary operator to check if the temperature is too hot, too cold, or just good. Assign the result in a variable then display the result. Assume that below 10 degrees is "Just Cold", above 30 degrees is "Just Hot", and anything else is "Just Good".
            Console.WriteLine("Plese enter a temperature  ");
            var temperature = double.Parse(Console.ReadLine());
            var res = (temperature < 10) ? "Just Cold" : (temperature > 30) ? "Just Hot" : "Just Good";
            Console.WriteLine("temperature is : " + res);

            #endregion

            #region Q11:Write a program that takes the date from the user and displays it in various formats using string interpolation.

            Console.WriteLine("Enter a date: ");

            Console.Write("Enter a month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter a year: ");
            int year = int.Parse(Console.ReadLine());

            DateTime date = new DateTime(year, month, day);


            Console.WriteLine($" date : {date:MM/dd/yyyy}");
            Console.WriteLine($" date : {date:MM-dd-yyyy}");
            Console.WriteLine($" date : {date:MM,dd,yyyy}");
            Console.WriteLine($" date : {date:MMM-dd-yyyy}");
            Console.WriteLine($" date : {date:MMM-ddd-yyyy}");


            #endregion

            #region Q12:What is the output of the following C# code?


            //DateTime date = new DateTime(2024, 6, 14);
            //Console.WriteLine($"The event is on {date:MM/dd/yyyy}")


            // The event is on 06/14/2024

            // output : 06 / 14 /2024


            #endregion


            #region Q13:Which of the following statements is correct about the C#.NET code snippet given below?



            //int d;
            //d = Convert.ToInt32(!(30 < 20));



            //Ans:

            //f) A value 1 will be assigned to d.




            #endregion


            #region Q14:Which of the following is the correct output for the C# code given below?



            // Console.WriteLine(13 / 2 + " " + 13 % 2);



            //Ans:

            //d) 6 1

            #endregion


            #region Q15:What will be the output of the C# code given below?


            //int num = 1, z = 5;


            //if (!(num <= 0))
            //    Console.WriteLine(++num + z++ + " " + ++z);
            //else
            //    Console.WriteLine(--num + z-- + " " + --z);




            //Ans:

            //d)7 7

            #endregion







        }
    }
}
