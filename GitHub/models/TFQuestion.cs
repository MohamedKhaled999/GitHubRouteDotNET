using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.models
{
    internal class TFQuestion : Question
    {

        public TFQuestion( string body, int mark, int rightId) : base("True OR False Question", body, mark,new string[]{"true","false"},  rightId)
        {
            
        }
        public override void Show(bool showAns)
        {
            
           string res = $""""
                        {Header}                                  {Mark} Marks
                        {Body}
                        ------------------------------------------------------
                        {String.Join("\n",Answers)}

                        """";
            
            if (showAns)
            {
                res += $"The Right Answer => {RightAnswer.ToString()}";
            }

            Console.WriteLine(res);
        }
    }
}
