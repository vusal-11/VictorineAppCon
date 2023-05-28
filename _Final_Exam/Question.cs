using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Final_Exam
{
    internal class Question
    {

        
            public string QuestionName { get; set; }
            public string AnswerA { get; set; }
            public string AnswerB { get; set; }
            public string AnswerC { get; set; }
            public string AnswerD { get; set; }

            public string Correct { get; set; }

            public Question(string questionName, string answerA, string answerB, string answerC, string answerD, string correct)
            {
                QuestionName = questionName;
                AnswerA = answerA;
                AnswerB = answerB;
                AnswerC = answerC;
                AnswerD = answerD;
                Correct = correct;
            }

            public Question()
            {}
        
    }
}
