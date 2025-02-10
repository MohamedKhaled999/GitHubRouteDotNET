using System.Collections;

namespace DEMOAdv3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            #region Hashtable


            // Hashtable phoneBook = new Hashtable();

            //phoneBook.Add("Ahmed", 123); // 123697
            //phoneBook.Add("Ahmed", 789); // 123697

            ////Console.WriteLine(phoneBook["Ahmed"]);

            //string name01 = "Ahmed";
            //string name02 = "Ahmed";

            //Console.WriteLine(name01.GetHashCode());
            //Console.WriteLine(name02.GetHashCode());

            //Console.WriteLine(name01.Equals(name02));

            //int x = 10;
            //int y = 10;
            //Console.WriteLine(x.GetHashCode());
            //Console.WriteLine(y.GetHashCode());
            //Console.WriteLine(x.Equals(y));



            #endregion

            #region Dictionary
            //Dictionary<string,int> phoneBook = new Dictionary<string,int>();
            //phoneBook.Add("Ahmed", 123);

            //phoneBook.Add("Ahmed", 456); // invalid

            //if (!phoneBook.ContainsKey("Ahmed"))
            //    phoneBook.Add("Ahmed", 789); 

            //else
            //    phoneBook["Ahmed"] = 456; 


            //if(!phoneBook.TryAdd("Ahmed" , 123))
            //    phoneBook["Ahmed"] = 456; 


            //Console.WriteLine(phoneBook["Ahmed"]); 


            //phoneBook.TryGetValue("Ahmed", out int result);
            //Console.WriteLine(result);

            //phoneBook.TryAdd("hamdaaa", 999);
            //phoneBook.TryAdd("Omar", 789);

            ////foreach(var person in phoneBook)
            ////{
            ////    Console.WriteLine(person);
            ////}
            //foreach(string person in phoneBook.Keys)
            //{
            //    Console.WriteLine(person);
            //}

            #endregion

            #region SortedDictionary & SortedList

            //SortedDictionary<string , int> sortedPhoneBook = new SortedDictionary<string , int>();

            //sortedPhoneBook.TryAdd("Ahmed", 123);
            //sortedPhoneBook.TryAdd("Zyad", 456);
            //sortedPhoneBook.TryAdd("Omar", 888);

            //foreach(var phoneBook in sortedPhoneBook)
            //    Console.WriteLine(phoneBook);


            //SortedList<string , int> sortedList = new SortedList<string , int>();   
            // Array[string] , Array[int] 



            #endregion

            #region Hashset  
            // data is unique
            //HashSet<int> numbers = new HashSet<int>();

            //numbers.Add(1);  // 1 
            //numbers.Add(2);
            //numbers.Add(3);

            //foreach (int i in numbers)
            //{
            //    Console.WriteLine(i);
            //}

            //HashSet<string> names = new HashSet<string>();
            //names.Add("Ahmed");
            //names.Add("Mona");
            //names.Add("Ahmed");

            //foreach (string i in names)
            //{
            //    Console.WriteLine(i);
            //}


            //HashSet<Movie> movies = new HashSet<Movie>();
            //movies.Add(new Movie() { Id = 100 , Title = "Avatar" , Price = 120}); 
            //movies.Add(new Movie() { Id = 200, Title = "Bank El Haz", Price = 130 });
            //movies.Add(new Movie() { Id = 300, Title = "1000 mabrok", Price = 120 });
            //movies.Add(new Movie() { Id = 100, Title = "Avatar", Price = 120 });


            //foreach (Movie movie in movies)
            //{
            //    Console.WriteLine(movie);
            //}

            #endregion



        }
    }
}
