
namespace GitHub.models
{
    internal class PracticalExam:Exam
    {
        

        public PracticalExam(int numOfQuestions, double time, List<Question> questions): base(time, numOfQuestions, questions)
        {
           
        }


        public override void ShowExam(List<Answer> UserAnswers)
        {
            int UserGrade = 0;
            int TotalExamGrade = 0;


            string res = $""""
                                             PracticalExam
                         ------------------------------------------------------
                         

                         """";
            Console.WriteLine(res);
            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.Write($"Q:{i + 1} ");
                Questions[i].Show(true);
                //Console.WriteLine($"Your Answer => {UserAnswers[i]}");

                //if (UserAnswers[i].AnswerId == Questions[i].RightAnswer.AnswerId)
                //    UserGrade += Questions[i].Mark;

               // TotalExamGrade += Questions[i].Mark;

            }

            //Console.WriteLine($"Your Grade is {UserGrade} of {TotalExamGrade}");

            //Console.WriteLine($"Your Time Is : {StopExam()}");

            Console.WriteLine("Thank You ");



        }



    }
}