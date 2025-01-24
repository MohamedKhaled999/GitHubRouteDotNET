namespace GitHub.models
{
     class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exam Exam { get; set; }
        public List<Answer> UserAnswer { get; set; } = new();
        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void CreateExam(int NumOfQuestions,double time, int typeOfExam = 1)
        {

            Exam = (typeOfExam == 1) ?new PracticalExam(NumOfQuestions,time,GenQuestions(typeOfExam, NumOfQuestions)): new FinalExam (NumOfQuestions, time, GenQuestions(typeOfExam, NumOfQuestions));
            BeginExam();
            

        }

       private void BeginExam()
        {
            Console.Clear();

            bool enterd =false;
            string res;
            do
            {
               Console.WriteLine("Do You Want Start Exam (Y|N)");
                res= Console.ReadLine().ToLower();
               if (res == "y" || res == "n")
                   enterd = true;
            } while (!enterd);

            if ( res == "n") return; 

            Console.Clear();
            Exam.StartExam();
                                                        
            Console.WriteLine((Exam is FinalExam)? "\t\t\tFinal Exam" : "\t\t\tPractical Exam");
            Console.WriteLine("-------------------------------------------------------");
            for (int i = 0; i < Exam.Questions.Count; i++)
            {
                Exam.Questions[i].Show(false);

                bool entered = false;
                int id;
                do
                {
                   
                    Console.WriteLine($"Please Enter Your The Answer Id ");

                    entered = int.TryParse(Console.ReadLine(), out id);
                    entered = (id > 0 && id <= Exam.Questions[i].Answers.Count ) ? entered : false;

                } while (!entered);

                UserAnswer.Add(Exam.Questions[i].Answers[id-1]);

            }

            Console.Clear() ;
            Exam.ShowExam(UserAnswer);




        }



        private List<Question> GenQuestions(int typeOfExam,int NumOfQuestions)
        {
            
            var questions = new List<Question>();
            for (int i = 1; i <= NumOfQuestions; i++)
            {
                Console.Clear();
               bool entered = false;
                int type=2;
                if (typeOfExam==2)
                {
                    do
                    {
                        Console.WriteLine("Please Enter Type Of Question (1 for MCQ |2 True/False)");

                        entered = int.TryParse(Console.ReadLine(), out type);
                        entered = (type > 0 && type < 3) ? entered : false;

                    } while (!entered);

                }


                if (type == 1)
                    questions.Add(GenMCQ());
                else
                    questions.Add(GenTF());

            }


            return questions ;
        }

        private Question GenMCQ()
        {
            Console.WriteLine("MCQ Question");
            Console.WriteLine("Please Enter Question Body");
            var body = Console.ReadLine();
            bool entered = false;
            int mark;

            do
            {
               
                Console.WriteLine("please Enter Mark Of Question");
                entered = int.TryParse(Console.ReadLine(), out mark);

            } while (!entered);

            Console.WriteLine("Choices Of Question");

            string[] choices = new string[3];
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Please Enter Choice Number {i}");
                choices[i-1] = Console.ReadLine();
            }

             entered = false;
            int id;
            do
            {
                

                Console.WriteLine("please Enter Id Of The Right Answer");
               entered= int.TryParse(Console.ReadLine(), out id);
                entered = (id > 0 && id < 4) ? entered : false;

            } while (!entered);



            return new MCQuestion(body,mark,choices,id);
        }



        private Question GenTF()
        {
            Console.WriteLine("True/False Question");
            Console.WriteLine("Please Enter Question Body");
            var body = Console.ReadLine();
            bool entered = false;
            int mark;

            do
            {
                

                Console.WriteLine("please Enter Mark Of Question");
                entered = int.TryParse(Console.ReadLine(), out mark);

            } while (!entered);

        
            entered = false;
            int id;
            do
            {

                Console.WriteLine("please Enter Id Of The Right Answer  [ 1 for true | 2 for false ]");
                entered = int.TryParse(Console.ReadLine(), out id);
                entered =(id>0&&id<3) ? entered : false;

            } while (!entered);



            return new TFQuestion(body, mark, id);
        }


    }
}