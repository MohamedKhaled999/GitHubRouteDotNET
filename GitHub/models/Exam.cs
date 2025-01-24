using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GitHub.models
{
    internal abstract class Exam
    {
        public double Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }
        private Stopwatch _stopwatch;
        public Exam(double time, int numberOfQuestions, List<Question> questions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = questions;
        }
        
        public void StartExam()
        {
            _stopwatch = Stopwatch.StartNew();
        }
        
        public string StopExam()
        {
            _stopwatch.Stop();
            return _stopwatch.Elapsed.ToString()+" s";
        }

        public abstract void ShowExam(List<Answer> UserAnswers);
    }
}
