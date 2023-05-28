using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Final_Exam
{
    public class Answer
    {
        public string QuestionName { get; set; }
        public string UserAnswer { get; set; }
        public string Correct { get; set; }


        public Answer(string questionName, string userAnswer, string correct)
        {
            QuestionName = questionName;
            UserAnswer = userAnswer;
            Correct = correct;
        }
    }
}
