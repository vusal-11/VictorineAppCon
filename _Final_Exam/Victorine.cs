using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Final_Exam
{
    internal class Victorine
    {
        


            public List<Question> Questions { get; set; }
            public List<Answer> Answers { get; set; }

            public int PointCount { get; set; }

            public void GetQuestions(string x)
            {
                FileLibrary fl = new FileLibrary();
                List<Question> questions = fl.GetQuestions(x);
                this.Questions = questions;
            }

            public void PostAnswers(User user, string examtype)
            {
                
                FileLibrary fl = new FileLibrary();
                fl.PostAnswers(user.Login, this, "res" + examtype);
            }



            public void StartVicroine(User user)
            {
                Console.WriteLine();
                Console.WriteLine("\tChoose Type of victorine");
                Console.WriteLine();

                


                List<string> questionFileNames = this.getQuestionFileNames();
                for (int i = 0; i < questionFileNames.Count; i++)
                {
                    Console.WriteLine($"\tFor Questions by {questionFileNames[i]} press -> {i + 1}");
                }
                Console.WriteLine("\tFor exit press any 0");
                string examType = Console.ReadLine();
                Console.Clear();


                if (examType == "0") return;

                int.TryParse(examType, out int type);
                if (type <= 0 || type > questionFileNames.Count)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tFalse choice,try again");
                    return;
                }
                this.GetQuestions(questionFileNames[type - 1]);

               

                List<Answer> answers = new List<Answer>();

                int totalpoint = 0;
                for (int i = 0; i < Questions.Count; i++)
                {
                    Console.WriteLine("\tQuestion " + (i + 1));
                    Console.WriteLine();
                    Question question = this.Questions[i];
                    Console.WriteLine("\t"+question.QuestionName);
                    Console.WriteLine("\tA) " + question.AnswerA);
                    Console.WriteLine("\tB) " + question.AnswerB);
                    Console.WriteLine("\tC) " + question.AnswerC);
                    Console.WriteLine("\tD) " + question.AnswerD);
                    Console.WriteLine();
                    Console.WriteLine("\tPress A,B,C or D");
                    Console.WriteLine();
                    Console.Write("\tEnter your answer: ");


                    string correctAnswer = Console.ReadLine();
                    Console.Clear();
                    correctAnswer = correctAnswer.ToUpper();
                    correctAnswer = correctAnswer != null ? correctAnswer : "";

                    if (correctAnswer == question.Correct)
                    {
                        totalpoint++;
                    }




                    answers.Add(new Answer(question.QuestionName, correctAnswer, question.Correct));


                }
                this.Answers = answers;
                this.PointCount = totalpoint;
                this.PostAnswers(user, questionFileNames[type - 1]);

                Console.WriteLine();
                Console.WriteLine($"\tYou finished {questionFileNames[type-1]} Victorine!!!");
        }


        public List<string> getQuestionFileNames()
            {
                List<string> result = new List<string>();
                FileLibrary fl = new FileLibrary();
                result = fl.listFileNames("Questions", "*.json");
                return result;
            }



        }
    
}
