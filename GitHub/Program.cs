namespace GitHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            #region Part 1

            #region Student
            Student student = new Student();
            bool isParsed;

            Console.WriteLine("Please Enter Student Data:");


            Console.WriteLine("Name => ");
            student.Name = Console.ReadLine();

            Console.WriteLine("Grade (A, B, C, D, F) => ");
            Grade grade;
            do
            {
                isParsed = Enum.TryParse(Console.ReadLine(), true, out grade);
            } while (!isParsed);

            student.StudentGrade = grade;

            Console.WriteLine("Branch ( Dokkie, Alex Maadi) => ");
            Branch branch;
            do
            {
                isParsed = Enum.TryParse(Console.ReadLine(), true, out branch) ;
            } while (!isParsed);
            student.StudentBranch = branch;

            Console.WriteLine("Gender (Male, Female,M,F) => ");
            Gender gender;
            do
            {
                isParsed = Enum.TryParse(Console.ReadLine(), true, out gender) ;
            } while (!isParsed);
            student.StudentGender = gender;

            student.Print();
            #endregion

            #region User
            User user = new User();
            user.Id = 2;
            user.Permission = Permission.Read ^Permission.Write;
            Console.WriteLine($"user ==> id : {user.Id} \nPermission : {user.Permission}");


            #endregion

            #endregion

            #region Part 2
            #region Q1: Create an enum called "WeekDays" with the days of the week (Monday to Sunday) as its members. Then, write a C# program that prints out all the days of the week using this enum.


            foreach (var day in Enum.GetNames<WeekDays>())
            {
                Console.WriteLine(day);
            }




            #endregion

            #region Q2:Create an enum called "Seas on" with the four seasons (Spring, Summer, Autumn, Winter) as  its members.
            // Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season.
            // Note range for seasons ( spring march to may , summer june to august , autumn September to November , winter December to February)


            Console.WriteLine("please enter a season name (Spring, Summer, Autumn, Winter) \n------------------------------------------------");
           string season = Console.ReadLine();
            

           Enum.TryParse<Season>(season,true ,out var season2);
         
            switch (season2) 
            { 
                case Season.Autumn: 
                    Console.WriteLine("September to November");
                    break;

                case Season.Summer:
                    Console.WriteLine("june to august");
                    break;
                case Season.Winter:
                    Console.WriteLine("December to February");
                    break;
                case Season.Spring:
                    Console.WriteLine("march to may");
                    break;
            }


            #endregion

            #region Q3:Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum
            //Create Variable from previous Enum to Add and Remove Permission from variable,
            //check if specific Permission is existed inside variable

            Permission permission = Permission.None;
            //add 
            permission = permission ^ Permission.Write;
            permission = permission ^ Permission.Read;

            Console.WriteLine(permission);
            //remove
            permission = permission ^ Permission.Write;
            Console.WriteLine(permission);

            //check 
            if ((permission & Permission.Write) == Permission.Write)
                Console.WriteLine(" found");
            else
                Console.WriteLine(" not found !");


            #endregion


            #region Q4: Create an enum called "Colors" with the basic colors (Red, Green, Blue) as its members.
            //Write a C# program that takes a color name as input from the user and displays a message indicating whether the input color is a primary color or not.


            Console.WriteLine("please enter a color name (Red, Green, Blue) \n------------------------------------------------");
            string color = Console.ReadLine();

            if (Enum.TryParse<Color>(color, true,out var color2))
                Console.WriteLine("the input color is a primary");
            else
                Console.WriteLine("the input color is't a primary");


            #endregion

            #endregion

        }


    }


    #region Part1
    #region Student
    enum Grade
    {
        A,
        B,
        C,
        D,
        F
    }

    enum Branch
    {
        Dokkie,
           Alex ,
           Maadi

    }

    enum Gender
    {
        Male=1,
        M=1,
        Female=2,
        F=2
        
    }

    class Student
    {
        public string Name { get; set; }
        public Grade StudentGrade { get; set; }
        public Branch StudentBranch { get; set; }
        public Gender StudentGender { get; set; }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Grade: {StudentGrade}");
            Console.WriteLine($"Branch: {StudentBranch}");
            Console.WriteLine($"Gender: {StudentGender}");
        }
    }
    #endregion

    #region User
    class User
    {
        public int Id { get; set; }
        public Permission Permission { get; set; }
    }

    #endregion


    #endregion

    #region Q1: Create an enum called "WeekDays" with the days of the week (Monday to Sunday) as its members. Then, write a C# program that prints out all the days of the week using this enum.
    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    #endregion


    #region Q2:Create an enum called "Seas on" with the four seasons (Spring, Summer, Autumn, Winter) as  its members.
    // Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season.
    // Note range for seasons ( spring march to may , summer june to august , autumn September to November , winter December to February)

    enum Season
    {
        Spring, 
        Summer,
        Autumn, 
        Winter
    }



    #endregion

    #region Q3:Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum
    [Flags]
    enum Permission
    {
        None = 0,
        Read = 1,
        Write = 2,
        Delete = 4,
        Execute = 8
    }
    #endregion

    #region Q4: Create an enum called "Colors" with the basic colors (Red, Green, Blue) as its members.
    //Write a C# program that takes a color name as input from the user and displays a message indicating whether the input color is a primary color or not.

    enum Color
    {
        Red, Green, Blue
    }
    #endregion
}






