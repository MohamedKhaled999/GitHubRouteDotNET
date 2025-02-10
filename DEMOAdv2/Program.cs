namespace DEMOAdv2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region Non-Generic Collection  ArrayList
            //int[] numbers = new int[5];
           
            ////ICollection collection = new int[] { 1, 2, 3, 4, 5 };

            //ArrayList list = new ArrayList(new int[] { 1, 2, 3, 4, 5 });

            //Console.WriteLine($"Count  :{list.Count} :: Capacity : {list.Capacity}");


            ////list[0] = 45; 
            ////list[0] = 45;
            ////Console.WriteLine(list[0]);
            //list.Add(58); 
            //Console.WriteLine($"Count  :{list.Count} :: Capacity : {list.Capacity}");

            //list.TrimToSize();
            //Console.WriteLine($"Count  :{list.Count} :: Capacity : {list.Capacity}");

            //Console.WriteLine(Sum(list));
            #endregion

            #region Generic Collection List<T>


            //IEnumerable<int> collection = new int[] { 1, 2, 3, 4 };
            //List<int> list = new(collection);
            //Console.WriteLine($"Count  :{list.Count} :: Capacity : {list.Capacity}");
            //list.Add(5);
            //Console.WriteLine($"Count  :{list.Count} :: Capacity : {list.Capacity}");
            //list.TrimExcess();
            //Console.WriteLine($"Count  :{list.Count} :: Capacity : {list.Capacity}");
            #endregion

            #region Generic List<T> Methods 

            //IEnumerable<int> collection = [1, 2, 3];//C# 12.0
            //List<int> list = new(collection);
            //Console.WriteLine($"Count  :{list.Count} :: Capacity : {list.Capacity}");

            //list.AddRange([4, 5, 6]);
            //Console.WriteLine($"Count  :{list.Count} :: Capacity : {list.Capacity}");

            //list.Clear();
            //Console.WriteLine($"Count  :{list.Count} :: Capacity : {list.Capacity}");
            //list[1] = 10;

            //int index = list.BinarySearch(6); Console.WriteLine(index);

            //List<Employee> employees = [
            //      new(10, "Ahmed", 21, 50000),
            //     new(20, "Mahmoud", 32, 31210),
            //     new(40, "Ahmed", 25, 55555),
            //     new(30, "Sayed", 45, 111111),
            //     new(1, "Sayed", 45, 111111)
            //     ];


            //int index = employees.BinarySearch(new(10, "Ahmed", 21, 50000));
            //Console.WriteLine(index);
            //bool flag = employees.Contains(new(30, "Sayed", 45, 111111));

            //Console.WriteLine(flag);

            //employees.LastIndexOf()

            //employees.InsertRange(0, );

            //employees.Sort();
            //Console.WriteLine(employees.ToString());
            #endregion

            #region Generic Collection LinkedList<T>


            //LinkedList<int> numbers = new([1, 2, 3]);

            ////Console.WriteLine(numbers.First.);
            ////Console.WriteLine(numbers.Last.Value);
            //numbers.AddFirst(50);
            //numbers.AddLast(25);
            //numbers.AddAfter(numbers.Find(3), 44);
            //numbers.AddBefore(numbers.First, new LinkedListNode<int>(88));
            //foreach (var item in numbers)
            //{
            //    Console.WriteLine(item);
            //}


            #endregion

            #region Generic Collection Stack<T>
            //Stack<int> numbers = new([1, 2, 3]);
            //numbers.Push(4);
            //numbers.Push(5);


            //Console.WriteLine(numbers.Pop()); 
            //Console.WriteLine(numbers.Pop()); 
            //Console.WriteLine(numbers.Pop()); 
            //Console.WriteLine(numbers.Peek()); 
            //Console.WriteLine(numbers.TryPeek(out int number));
            //Console.WriteLine(number);

            //foreach (var item in numbers)
            //{
            //    Console.WriteLine(item);
            //}


            #endregion

            #region Generic Collection Queue<T>
            //Queue<int> numbers = new([5, 8, 7]);


            //numbers.Enqueue(6);

            //numbers.Dequeue();
            //numbers.TryDequeue();

            //numbers.Peek();
          //  numbers.TryPeek();
          //foreach (var item in numbers)
          //{
          //      Console.WriteLine(item);
          // }
            #endregion



        }
    }
}
