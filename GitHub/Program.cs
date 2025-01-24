using GitHub.models;

namespace GitHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");




            Subject sub = new(455,"C#");


            bool entered = false;
            int type;
            do
            {

                Console.WriteLine("Please Enter type of Exam (1 for Practical | 2 Final)");
                entered = int.TryParse(Console.ReadLine(), out type);
                entered = (type > 0 && type < 3) ? entered : false;

            } while (!entered);

            entered = false;
            int numOfQ;
            do
            {

                Console.WriteLine("Please number  of Questions");
                entered = int.TryParse(Console.ReadLine(), out numOfQ);

            } while (!entered);


            entered = false;
            double mins;
            do
            {

                Console.WriteLine("Please Enter Time of Exam (30 min  to 120 min)");
                entered = double.TryParse(Console.ReadLine(), out mins);
                entered = (mins > 29 && mins < 121) ? entered : false;


            } while (!entered);


            sub.CreateExam(numOfQ,mins,type);
        }
    }
}
