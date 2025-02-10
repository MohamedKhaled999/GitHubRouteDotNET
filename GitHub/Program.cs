using System.Collections;
using System.Collections.Generic;

namespace GitHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region reverse the order of elements in the ArrayList 
            /*
             * 1.	You are given an ArrayList containing a sequence of elements. 
             * try to reverse the order of elements in the ArrayList in-place(in the same arrayList)
             * without using the built-in Reverse.
             * Implement a function that takes the ArrayList as input and modifies it to have the reversed order of elements.
             */


            ArrayList array = new ArrayList() { 1, 2, 3, 4, "ss", 56, 99, "ss" };

            foreach (var item in array)
            {
                Console.WriteLine($"{item} ");
            }
            Console.WriteLine("After the MyReverse");
            MyReverse(array);
            foreach (var item in array)
            {
                Console.WriteLine($"{item} ");
            }

            #endregion


            #region You are given a list of integers. Your task is to find and return a new list containing only the even numbers from the given list.

            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("\n\n\n\new list containing only the even numbers");
            foreach (var item in GetEvens(list))
            {
                Console.WriteLine(item);
            }


            #endregion

            #region FixedSizeList
            Console.WriteLine("\n\n\n\nFixedSizeList");
            FixedSizeList<int> fixedList = new(5);
            fixedList.Add(1);
            fixedList.Add(2);
            fixedList.Add(3);
            fixedList.Add(4);
            Console.WriteLine(fixedList.Get(3));
            fixedList.Add(5);
            fixedList.Add(6);

            #endregion

        }




        public static void MyReverse(ArrayList array)
        {
            for (int i = 0; i < array.Count / 2; i++)
            {
                object temp = array[i];
                array[i] = array[array.Count - i - 1];
                array[array.Count - i - 1] = temp;

            }
        }


        public static List<int> GetEvens(List<int> array)
        {
            var list = new List<int>();

            foreach (var item in array)
            {
                if (item % 2 == 0)
                {
                    list.Add(item);
                }
            }


            return list;

        }
    }
    }
