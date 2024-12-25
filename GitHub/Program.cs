using System;
using System.Buffers.Text;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GitHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1:Explain the difference between passing (Value type parameters) by value and by reference then write a suitable c# example.
            /*
             *Passing by Value :
             *  *When a parameter is passed by value  a copy of the actual data is passed to the function. Changes made to the parameter inside the function do not affect the original data.
             *
             *Passing by Reference:
             * *When a parameter is passed by reference the function works with the original data rather than a copy.Changes made to the parameter inside the function directly affect the original data.
             * **/


            /*Example*/
            //Passing by Value 
           
            int x = 5;
            add10(5);
            void add10(int x) { x += 10; }
            Console.WriteLine(x); // not changed 
            //Passing by Reference

            add10(5);
            void add5(ref int x) { x += 5; }
            Console.WriteLine(x); //  changed 




            #endregion


            #region Q2:Explain the difference between passing (Reference type parameters) by value and by reference then write a suitable c#example.
            /* 
             * by value 
             **** When a reference type is passed by value, address is passed to another varible 
             ****So in stack we will have two varibles have the the same addres to data
             ****So ,Changes made to the parameter inside the function directly affect the original data.
             ****
             
             */
            var arr2 = new int[] { 10, 20, 30 };
            Modify(arr2);
            static void Modify(int[] array)
                {
                    array[0] = 99;                          // will change the 1st item in arr
                    
                    array = new int[] { 10, 20, 30 };       // local var array will point to another data
                                                            ////but cannot reassign the orginal reference 

            }


            /* 
           * by reference 
           **** When a reference type is passed by reference, alise is passed
           ****So in stack we will have one varible has the addres to data
           ****So ,Changes made to the parameter inside the function directly affect the original data.
           ****

           */
            var arr22 = new int[] { 10, 20, 30 };
            Modify2(ref arr22);
            static void Modify2( ref int[] array)
            {
                array[0] = 99;                          // will change the 1st item in arr
                array = new int[] { 10, 20, 30 };       // array(alise) and arr22 will point to another data
                                                        ////can reassign the orginal reference 
            }



            #endregion


            #region Q3:Write a c# Function that accept 4 parameters from user and return result of summation and subtracting of two numbers


            Console.WriteLine("summation and subtracting of two numbers\n------------------------------------------------------");
            Console.WriteLine("enter 1st num :");
            double x3 = double.Parse(Console.ReadLine());
            Console.WriteLine("enter 2nd num :");
            double x33 = double.Parse(Console.ReadLine());
            // the function implemtaion below ↓↓↓↓↓↓↓
            GetSumSub(x3, x33, out double sum, out double sub);
            // the function implemtaion below ↓↓↓↓↓↓↓

            Console.WriteLine($"sum is : {sum}");
            Console.WriteLine($"sub is : {sub}");


            #endregion

            #region Q4:Write a program in C# Sharp to create a function to calculate the sum of the individual digits of a given number.


            Console.WriteLine("calculate the sum of the individual digits of a given number   \n  ------------------------------------------------------");
            Console.WriteLine("enter your num :");
            int x4 = int.Parse(Console.ReadLine());

            // the function implemtaion below ↓↓↓↓↓↓↓

            Console.WriteLine($"sum of the individual digits of a given number is : {SumOfDigits(x4)}");
            // the function implemtaion below ↓↓↓↓↓↓↓


            #endregion


            #region Q5:Create a function named "IsPrime", which receives an integer number and retuns true if it is prime, or false if it is not:


            Console.WriteLine(" function named is prime, which receives an integer number and retuns true if it is prime, or false if it is not   \n  ------------------------------------------------------");
            Console.WriteLine("enter your num :");
            int x5 = int.Parse(Console.ReadLine());

            // the function implemtaion below ↓↓↓↓↓↓↓

            Console.WriteLine($"the given number {x5} is prime num ? : {IsPrime(x5)}");
            // the function implemtaion below ↓↓↓↓↓↓↓


            #endregion

            #region Q6:Create a function named MinMaxArray, to return the minimum and  maximum values stored in an array, using reference parameters
            int[] myArr = [1,5,10,0,2,7,9];
            int min = 0, max = 0;
            // the function implemtaion below ↓↓↓↓↓↓↓

            MinMaxArray(myArr,ref min, ref max);
            Console.WriteLine($"min value is : {min}  ,  max value is : {max}");

            #endregion

            #region Q7:Create an iterative(non-recursive) function to calculate the factorial of the number specified as parameter
            Console.WriteLine("\nfunction to calculate the factorial of the number \n  ------------------------------------------------------");
            Console.WriteLine("enter your num :");
            int x7 = int.Parse(Console.ReadLine());
            // the function implemtaion below ↓↓↓↓↓↓↓

            Console.WriteLine($" the factorial of  {x7} is : {factorial(x7)}");
            #endregion

            #region Q8:Create a function named Change Char to modify a letter in a certain position(0 based) of a string, replacing it with a different letter
            Console.WriteLine("\nfunction named Change Char to modify a letter in a certain position(0 based)  \n  ------------------------------------------------------");
            Console.WriteLine("enter your string :");
            string x8 = Console.ReadLine();
            Console.WriteLine($" before change : {x8}");
            // the function implemtaion below ↓↓↓↓↓↓↓

            changeLetter(ref x8);
            Console.WriteLine($" after change  : {x8}");
            #endregion


        }




        //  functions implemtaion below ↓↓↓↓↓↓↓



        #region Q3:Write a c# Function that accept 4 parameters from user and return result of summation and subtracting of two numbers

        public static void GetSumSub(double x1, double x2, out double sumResult, out double subResult)
        {
            sumResult = x1 + x2;
            subResult = x2 - x1;

        }
        #endregion

        #region Q4:Write a program in C# Sharp to create a function to calculate the sum of the individual digits of a given number.

        public static int SumOfDigits(int num)
        {

            int sum = 0;

            do
            {
                sum += (num % 10);
                num = (num / 10);
            }
            while (num > 0);
            return sum;
        }


        #endregion


        #region Q5:Create a function named "IsPrime", which receives an integer number and retuns true if it is prime, or false if it is not:

        public static bool IsPrime(int x5)
        {
            if (x5 <2) return false;

            for (int i = 2;i<=Math.Sqrt(x5);i++)
                    if (x5%i == 0) return false;
            return true;
        }

        #endregion


        #region Q6:Create a function named MinMaxArray, to return the minimum and  maximum values stored in an array, using reference parameters

        static void MinMaxArray(int[] arr, ref int min, ref int max)
        {
            min =max= arr[0];


            
            foreach (int value in arr)
            {
                if (value < min)
                {
                    min = value;
                }
                if (value > max)
                {
                    max = value;
                }
            }


        }

        #endregion

        #region Q7:Create an iterative(non-recursive) function to calculate the factorial of the number specified as parameter
        public static int factorial(int x)
        {
             int fact = 1;
            for (int i = 2; i <= x; i++)
                fact *= i;

            return fact;
        }

        #endregion

        #region Q8:Create a function named Change Char to modify a letter in a certain position(0 based) of a string, replacing it with a different letter

        private static void changeLetter(ref string x7)
        {
             x7= "?"+x7.Substring(1) ;
        }
        #endregion



    }
}
