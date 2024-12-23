using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GitHub
{
    internal class Program
    {
        static void Main(string[] args)
        {



            #region Q1:Write a program that takes a number from the user then print yes if that number can be divided by 3 and 4 otherwise print no.


            bool check;
            do
            {

                Console.WriteLine("Q1:Please enter Number :");
                check = int.TryParse(Console.ReadLine(), out int input);

                if (check)
                {
                    Console.WriteLine((input % 12 == 0 ? "Yes" : "No"));
                }

            } while (!check);



            #endregion


            #region Q2:Write a program that allows the user to insert an integer then print negative if it is negative number otherwise print positive.

            bool check2;
            do
            {

                Console.WriteLine("Q2:Please enter Number :");
                check2 = int.TryParse(Console.ReadLine(), out int input2);

                if (check2)
                {
                    Console.WriteLine((input2 > 0 ? "positive" : input2 < 0 ? "negative" : "Zero"));
                }

            } while (!check2);

            #endregion


            #region Q3:Write a program that takes 3 integers from the user then prints the max element and the min element.

            var inputs = Array.ConvertAll(Console.ReadLine().Split(""), int.Parse);

            Array.Sort(inputs);

            Console.WriteLine($"min : {inputs[0]}  \n max {inputs[inputs.Length - 1]}");

            #endregion


            #region Q4: Write a program that allows the user to insert an integer number then check If a number is even or odd.

            int input4;
            bool check4;
            do
            {
                Console.WriteLine("Q4:Please enter Number :");
                check4 = int.TryParse(Console.ReadLine(), out input4);
            } while (!check4);
            Console.WriteLine((input4 % 2 == 0 ? "even" : "odd"));

            #endregion



            #region Q5: Write a program that takes character from the user then if it is a vowel chars (a,e,I,o,u) then print (vowel) otherwise print (consonant).


            char x5;
            do
            {
                Console.WriteLine("Q5:Please enter a char :");
                x5 = (char)Console.Read();
                x5 = char.ToLower(x5);

            } while (!char.IsLetter(x5));

            switch (x5)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':

                    Console.WriteLine("vowel");
                    break;

                default:
                    Console.WriteLine("consonant");
                    break;
            }

            #endregion



            #region Q6: Write a program that allows the user to insert an integer then print all numbers between 1 to that number.


            int input6;
            bool check6;
            do
            {
                Console.WriteLine("Q6:Please enter Number :");
                check6 = int.TryParse(Console.ReadLine(), out input6);
            } while (!check6);

            for (int i = 1; i <= input6; i++)
            {
                Console.Write(i + ", ");
            }

            #endregion


            #region Q7: Write a program that allows the user to insert an integer then print a multiplication table up to 12.



            int input7;
            bool check7;
            do
            {
                Console.WriteLine("Q7:Please enter Number :");
                check7 = int.TryParse(Console.ReadLine(), out input7);
            } while (!check7);

            for (int i = 1; i <= 12; i++)
            {
                Console.Write(i * input7 + " ");
            }

            #endregion

            #region Q8:  Write a program that allows to user to insert number then print all even numbers between 1 to this number




            int input8;
            bool check8;
            do
            {
                Console.WriteLine("Q8:Please enter Number :");
                check8 = int.TryParse(Console.ReadLine(), out input8);
            } while (!check8);

            for (int i = 2; i <= input8; i += 2)
            {
                Console.Write(i + " ");
            }

            #endregion


            #region Q9:  Write a program that takes two integers then prints the power.



            int input9;
            int input99;
            bool check9;
            bool check99;
            do
            {
                Console.WriteLine("Q9:Please enter 1st. Number :");
                check9 = int.TryParse(Console.ReadLine(), out input9);
                Console.WriteLine("Q9:Please enter 2nd. Number :");
                check99 = int.TryParse(Console.ReadLine(), out input99);
            } while (!check9 && !check99);

            int power = 1;
            for (int i = 0; i < input99; i++)
            {
                power *= input9;
            }


            Console.WriteLine($"the power of {input9}^{input99} is : {power}");

            #endregion

            #region Q10:  Write a program to enter marks of five subjects and calculate total, average and percentage.




            int i10 = 0;
            int[] subjects = new int[5];
            int sum = 0;
            Console.WriteLine("Enter Marks of five subjects");
            do
            {
                Console.WriteLine($"Q10:Please enter subject . {i10 + 1}:");
                bool check10 = int.TryParse(Console.ReadLine(), out int input10);

                if (check10)
                {
                    i10++;
                    sum += input10;
                }


            } while (i10 < 5);


            Console.WriteLine($"Total marks = {sum}\nAverage Marks = {sum / 5}\n  Percentage = {(sum / 5) / sum:P}");

            #endregion


            #region Q11:Write a program to input the month number and print the number of days in that month.

            bool check11;
            int input11;
            do
            {
                Console.WriteLine($" Input: Month Number:");
                check11 = int.TryParse(Console.ReadLine(), out input11);



            } while (!check11 || (input11 < 0 || input11 > 11));


            Console.WriteLine($"Days in Month: {DateTime.DaysInMonth(2024, input11)}");

            #endregion


            #region Q12: Write a program to create a Simple Calculator.



            Console.Write("Q12:Enter the first number: ");
            double number1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Q12:Enter the second number: ");
            double number2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Choose an operation from [+, -, *, /] ");
            char operation = (char)Console.Read();
            Console.WriteLine();

            double result = 0;

            bool isvalid = false;

            switch (operation)
            {
                case '+':
                    result = number1 + number2;
                    isvalid = true;
                    break;
                case '-':
                    result = number1 - number2;
                    isvalid = true;
                    break;
                case '*':
                    result = number1 * number2;
                    isvalid = true;
                    break;
                case '/':
                    if (number2 != 0)
                    {
                        result = number1 / number2;
                        isvalid = true;
                    }
                    else

                        Console.WriteLine("Error: Division by zero is not allowed.");

                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
            if (isvalid)
            {
                Console.WriteLine($"result is : {result}");

            }


            #endregion

            #region Q13 : Write a program to allow the user to enter a string and print the REVERSE of it.
            Console.WriteLine("enter you string ");
            var s =Console.ReadLine();
            for (int i =s.Length-1 ; i >=0 ; i--)
            {
                Console.Write(s[i]);
            }

            #endregion

            #region Q14 :Write a program to allow the user to enter int and print the REVERSED of it.

            int input14;
            bool check14;
            do
            {
            Console.WriteLine("enter your int ");
                check14 = int.TryParse(Console.ReadLine(), out input14);
            } while (!check14);

            var s =input14.ToString();
            for (int i =s.Length-1 ; i >=0 ; i--)
            {
                Console.Write(s[i]);
            }

            #endregion


            #region Q15:  Write a program in C# Sharp to find prime numbers within a range of numbers.

            int input15;
            int input155;
            bool check15;
            bool check155;
            do
            {
                Console.WriteLine("Input starting number of range: ");
                check15 = int.TryParse(Console.ReadLine(), out input15);

                Console.WriteLine("Input ending number of range:");
                check155 = int.TryParse(Console.ReadLine(), out input155);

            } while (!check15 && !check155 );

            
            for (int i = input15; i <=input155; i++)
            {
                var isPrime = true;
                if (i < 2)
                    continue;

                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if(isPrime)
                  Console.Write(i+" ");
            }

            #endregion




            #region Q16: Write a program in C# Sharp to convert a decimal number into binary without using an array.

            int input16;

            bool check16;

            do
            {

                Console.WriteLine("enter a number to convert :  ");
                check16 = int.TryParse(Console.ReadLine(), out input16);


            } while (!check16);

            Console.WriteLine(Convert.ToString(input16,2));
            #endregion




            #region Q17: Create a program that asks the user to input three points (x1, y1), (x2, y2), and (x3, y3), and determines whether these points lie on a single straight line.

            int [] xPoints = new int[3];
            int [] yPoints = new int[3];

           
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Point{i+1}");
                Console.WriteLine("please enter x: ");
                if (int.TryParse(Console.ReadLine(), out xPoints[i]))
                {
                    i--;
                    continue;
                }

                Console.WriteLine("please enter y: ");
               if (int.TryParse(Console.ReadLine(), out yPoints[i]))
                {
                    i--;
                    continue;
                }
            }


            var str17=  (( (xPoints[0] - xPoints[1]) / (yPoints[0] - yPoints[1]) ) == ( (xPoints[0] - xPoints[2]) / (yPoints[0] - yPoints[2]) ) ) ?
                " these points lie on a single straight line" : " these points did not lie on a single straight line";

            Console.WriteLine(str17);

            #endregion


            #region Q18: Within a company, the efficiency of workers is evaluated based on the duration required to complete a specific task. A worker's efficiency level is determined as follows: 
            /*
             *- If the worker completes the job within 2 to 3 hours, they are considered highly efficient.
             *- If the worker takes 3 to 4 hours, they are instructed to increase their speed.
             *- If the worker takes 4 to 5 hours, they are provided with training to enhance their speed.
             *- If the worker takes more than 5 hours, they are required to leave the company.
            To calculate the efficiency of a worker, the time taken for the task is obtained via user input from the keyboard.*/

            double input18;
            bool check18;
            do
            {
               Console.WriteLine("Q18:Please Enter the time taken :");
               check18 = double.TryParse(Console.ReadLine(), out input18);
            } while (!check18||input18<0);


            if(input18<3)
                Console.WriteLine("highly efficient");
            else if(input18<4)
                Console.WriteLine("instructed to increase their speed");

            else if (input18<5)
                Console.WriteLine("they are provided with training to enhance their speed");

            else
                Console.WriteLine("they are required to leave the company.");



            #endregion


            #region Q19:Write a program that prints an identity matrix using for loop, in other words takes a value n from the user and shows the identity table of size n * n.
            int input19;
            bool check19;
            do
            {
                Console.WriteLine("Q19:Please Enter size of mat :");
                check19 = int.TryParse(Console.ReadLine(), out input19);
            } while (!check19);

            Console.WriteLine("Identity Mat. for Size = " + input19 + "is :");

            for (int i = 0; i < input19; i++)
            {
                for (int j = 0; j < input19; j++)
                {
                    if (i == j)
                        Console.Write(1+" ");
                    else 
                        Console.Write(0+" ");
                }
                Console.WriteLine();
            }

            #endregion

            #region Q20:Write a program in C# Sharp to find the sum of all elements of the array.
            int input20;
            bool check20;
            do
            {
                Console.WriteLine("Q20:Please Enter size of array :");
                check20 = int.TryParse(Console.ReadLine(), out input20);
            } while (!check20);


            int[] arr = new int[input20];
            int sum20 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"enter ele num.{i+1} ");
                arr[i] = int.Parse(Console.ReadLine());
                sum20 += arr[i];   
            }
            Console.WriteLine($"Sum of Array is   : {sum20}");

            #endregion

            #region Q21:Write a program in C# Sharp to merge two arrays of the same size sorted in ascending order.
            int[] arr1 = { 1, 6, 9, 7, 0 };
            int[] arr2 = { -4, 6, -9, 8, 1 };
            int[] newArr = new int[arr1.Length + arr2.Length];
            arr1.CopyTo(newArr, 0);
            arr2.CopyTo(newArr,arr1.Length);
            Array.Sort(newArr);
            foreach (int i in newArr)
                Console.Write(i+" ");
            #endregion


            #region Q22:Write a program in C# Sharp to count the frequency of each element of an array.

            int input22;
            bool check22;
            do
            {
                Console.WriteLine("Q23:Please Enter size of array :");
                check22 = int.TryParse(Console.ReadLine(), out input22);
            } while (!check22);


            int[] arr22 = new int[input22];

            for (int i = 0; i < arr22.Length; i++)
            {
                Console.WriteLine($"enter ele num.{i + 1} ");
                arr22[i] = int.Parse(Console.ReadLine());
            }

            int[] frequency = new int[arr22.Length];


            for (int i = 0; i < arr22.Length; i++)
            {
                if (frequency[i] ==-1)
                {
                    continue;
                }

                int cout = 1;
                for (int j = i+1; j < arr22.Length; j++)
                {

                    if (arr22[i] == arr22[j])
                    {
                        cout++;
                        frequency[j] = -1;
                    }
                }
                frequency[i] = cout;
            }


            for (int i = 0; i < arr22.Length; i++)
            {
                if (frequency[i] == -1)
                    continue;

                Console.WriteLine($"{arr22[i]}  frequency is : {frequency[i]}");
            }


            #endregion

            #region Q23:Write a program in C# Sharp to find maximum and minimum element in an array
            int input23;
            bool check23;
            do
            {
                Console.WriteLine("Q23:Please Enter size of array :");
                check23 = int.TryParse(Console.ReadLine(), out input23);
            } while (!check23);


            int[] arr23 = new int[input23];

            for (int i = 0; i < arr23.Length; i++)
            {
                Console.WriteLine($"enter ele num.{i + 1} ");
                arr23[i] = int.Parse(Console.ReadLine());
            }


            Array.Sort(arr23);

            Console.WriteLine($"Mix ele is {arr23[0]} \nMax ele is {arr23[arr23.Length-1]}");
            #endregion


            #region Q24:Write a program in C# Sharp to find the second largest element in an array.
            int input24;
            bool check24;
            do
            {
                Console.WriteLine("Q24:Please Enter size of array :");
                check24 = int.TryParse(Console.ReadLine(), out input24);
            } while (!check24);


            int[] arr24 = new int[input24];
            Array.Sort(arr24);
            Console.WriteLine(arr24[arr24.Length-2]);


            #endregion


            #region Q25:Consider an Array of Integer values with size N, having values as in this Example

            int input25;
            bool check25;
            do
            {
                Console.WriteLine("Q25:Please Enter size of array :");
                check25 = int.TryParse(Console.ReadLine(), out input25);
            } while (!check25);


            int[] arr25 = new int[input25];

            for (int i = 0; i < arr25.Length; i++)
            {
                Console.WriteLine($"enter ele num.{i + 1} ");
                arr25[i] = int.Parse(Console.ReadLine());
            }

            int maxDistance = 0;
            int indexMax = 0;

            for (int i = 0; i < arr25.Length; i++)
            {
                for (int j = i+1; j < arr25.Length; j++)
                {
                    if (arr25[i] == arr25[j])
                    {
                        if((j - i) >maxDistance)
                        {
                            maxDistance = j - i ;
                            indexMax = i;
                        }


                    }
                }

            }

           
            if (maxDistance > 0)
            {
                Console.WriteLine($"The longest distance is {maxDistance} cells for two cells  {indexMax} and {indexMax + maxDistance}.");
            }
            else
            {
                Console.WriteLine("No repeated elements found.");
            }


            #endregion

            #region Q26:Given a list of space separated words, reverse the order of the words.
            Console.WriteLine("Enter your words");
            var RWords =Console.ReadLine().Split(" ");
            for (int i = RWords.Length - 1; i > 0; i--)
                Console.Write(RWords[i] + " ");


            #endregion

            #region Q27:Write a program to create two multidimensional arrays of same size. Accept value from user and store them in first array. Now copy all the elements of first array on second array and print second array.


            Console.Write("Enter the number of rows: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of columns: ");
            int columns = int.Parse(Console.ReadLine());

            int[,] firstArray = new int[rows, columns];
            int[,] secondArray = new int[rows, columns];

            Console.WriteLine("enter elements for the first array:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"element at [{i},{j}]: ");
                    firstArray[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    secondArray[i, j] = firstArray[i, j];
                }
            }

                
            Console.WriteLine("\nelements of the second array:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(secondArray[i, j] + " ");
                }
                Console.WriteLine();
            }


            #endregion

            #region Q28: Write a Program to Print One Dimensional Array in Reverse Order
            int input28;
            bool check28;
            do
            {
                Console.WriteLine("Q28:Please Enter size of array :");
                check28 = int.TryParse(Console.ReadLine(), out input28);
            } while (!check28);


            int[] arr28 = new int[input28];


            for (int i = 0; i < arr28.Length; i++)
            {
                Console.WriteLine($"enter ele num.{i + 1} ");
                arr28[i] = int.Parse(Console.ReadLine());
            }

            for (int i = arr28.Length-1; i > 0; i--)
            {
                Console.Write(arr28[i]+" ");
            }


            #endregion



        }
    }
}
