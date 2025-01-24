using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.models
{
    internal class MCQuestion:Question
    {
        public MCQuestion( string body, int mark, String[] strings, int rightId) : base("MCQ Question Choose One Of The Followinq.", body, mark, strings, rightId)
        {

        }
        public override void Show(bool showAns)
        {

            string res = $""""
                        {Header}                          {Mark} Marks
                        {Body}
                        ------------------------------------------------------
                        {String.Join("\n", Answers)}

                        """";

            if (showAns)
            {
                res += $"The Right Answer => {RightAnswer.ToString()}";
            }

            Console.WriteLine(res);
        }
    }



}
