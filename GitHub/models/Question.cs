namespace GitHub.models
{
   abstract class   Question
    {

        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer RightAnswer { get; set; }
        public Answer UserAnswer { get; set; }
        public List<Answer> Answers { get; set; } = new();



       


        public Question(string header, string body, int mark, String[] strings, int rightId)
        {
            Header = header;
            Body = body;
            Mark = mark;
            addAnswers(strings);

            if (!(rightId > 0 && rightId <= strings.Length)) throw new IndexOutOfRangeException("choose from 1 to 3 only");
            RightAnswer = Answers[rightId-1];

        }

        private void addAnswers(String[] strings)
        {
           
            for (int i = 1; i <= strings.Length; i++)
            {
                Answers.Add(new(i, strings[i - 1]));
            }
        }


        public abstract void Show(bool showAns);
       

    }
}

