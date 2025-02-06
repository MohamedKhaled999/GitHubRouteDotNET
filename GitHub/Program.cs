namespace GitHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            #region 1.	The Bubble Sort algorithm has a time complexity of O(n^2) in its worst and average cases, which makes it inefficient for large datasets. How we can optimize the Bubble Sort algorithm And implement the code of this optimized bubble sort algorithm
            /*
                1.The Bubble Sort algorithm has a time complexity of O(n^2) in its worst and average cases, which makes it inefficient for large datasets. How we can optimize the Bubble Sort algorithm 
                And implement the code of this optimized bubble sort algorithm

             */

            List<int> list = new List<int>() { 1,8,10,7,8,0,29,-8,777};





            #endregion

            #region 2.Range <T>
            GitHub.Range<int> range = new(5,20);

            Console.WriteLine(range.IsInRange(10));
            Console.WriteLine(range.Length());

            #endregion
        }




       
    }
}
