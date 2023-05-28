using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _For_Admin
{
    internal class ManageVictorine
    {
        public ManageVictorine(){}


        public void createVictorine()
        {
            Console.WriteLine();
            Console.Write("\tEnter discipline name: ");
            string fileName = Console.ReadLine();
            if (!Directory.Exists($"../../../../res"+fileName))
            {
                Directory.CreateDirectory($"../../../../res" + fileName);
            }
            Question question = new Question();


            List<Question> questions = new List<Question>();
            bool enough = false;
            while (!enough)
            {
                Console.WriteLine();
                Console.Write("\tEnter the question Name: ");
                string questionName = Console.ReadLine();
                question.QuestionName = questionName;
                Console.Write("\tEnter the AnswerA: ");
                string answerA = Console.ReadLine();
                question.AnswerA = answerA;
                Console.Write("\tEnter the AnswerB: ");
                string answerB = Console.ReadLine();
                question.AnswerB = answerB;
                Console.Write("\tEnter the AnswerC: ");
                string answerC = Console.ReadLine();
                question.AnswerC = answerC;
                Console.Write("\tEnter the AnswerD: ");
                string answerD = Console.ReadLine();
                question.AnswerD = answerD;
                Console.Write("\tEnter Correct Answer: ");
                string correct = Console.ReadLine();
                question.Correct = correct.ToUpper();

                questions.Add(question);
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\tVictorine create succesfully");
                Console.WriteLine();
                Console.WriteLine("\tDo you want to add another question?");
                Console.WriteLine();
                Console.WriteLine("\tYes -- Press -> 1");
                Console.WriteLine("\tNo -- Press -> Any Key");

                string ans = Console.ReadLine();
                if (ans != "1")
                {
                    enough = true;
                }

                Console.Clear();

            }

            if (!File.Exists(fileName))
            {
                var myfile = File.Create(fileName);

                myfile.Close();
            }
            string stringQuestion = JsonConvert.SerializeObject(questions);

            using (StreamWriter writer = new StreamWriter(@$"../../../../Questions\{fileName}.json"))
            {

                writer.WriteLine(stringQuestion);
                writer.Close();
            }


        }


        public List<string> listFileNames(string dirName, string extention)
        {
            DirectoryInfo d = new DirectoryInfo(dirName); //Assuming Test is your Folder

            FileInfo[] Files = d.GetFiles(extention); //Getting Text files

            List<string> fileNames = new List<string>();
            foreach (FileInfo file in Files)
            {
                fileNames.Add(file.Name.Replace(".json", ""));
            }

            return fileNames;
        }

        public List<Question> GetQuestions(string fileName)
        {
            List<Question> questions = new List<Question>();
            using (StreamReader r = new StreamReader($"{"../../../../Questions"}\\{fileName}.json"))
            {
                string json = r.ReadToEnd();
                questions = JsonConvert.DeserializeObject<List<Question>>(json);
            }
            return questions;
        }





        public void postUpdateQuestions(string fileName,List<Question> update)
        {
            
            string path = @$"{"../../../../Questions"}\\{fileName}.json";

            File.Delete(path);

            var myfile = File.Create(path);

            myfile.Close();
            string strAnswers = JsonConvert.SerializeObject(update);

            using (StreamWriter writer = new StreamWriter(path))
            {

                writer.WriteLine(strAnswers);
                writer.Close();
            }

        }

        public void ChangeVictorine()
        {
            Console.Clear();
            Console.WriteLine("\tChoose which discipline that you want change");
            Console.WriteLine();
            Console.WriteLine("\tFor break press -> 0");
            ManageVictorine manage = new ManageVictorine();
            List<string> namesdicipline = manage.listFileNames("../../../../Questions", "*json");



            for (int i = 0; i < namesdicipline.Count; i++)
            {
                Console.WriteLine($"\tFor change  {namesdicipline[i]} press -> {i + 1} ");
            }
            string examType = Console.ReadLine();
            Console.Clear();


            if (examType == "0") return;

            int.TryParse(examType, out int type);
            if (type < 0 || type > namesdicipline.Count)
            {
                Console.WriteLine();
                Console.WriteLine("\tFalse choice,try again !!!");
                return;
            }


            List<Question> questions = manage.GetQuestions(namesdicipline[type - 1]);

            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"\tQuestion nO -> {i+1}");
                Console.WriteLine();
                Console.WriteLine($"\tQuestion name: "+questions[i].QuestionName);
                Console.WriteLine($"\tAnswer A: " + questions[i].AnswerA);
                Console.WriteLine($"\tAnswer B: " + questions[i].AnswerB);
                Console.WriteLine($"\tAnswer C: " + questions[i].AnswerC);
                Console.WriteLine($"\tAnswer D: " + questions[i].AnswerD);
                Console.WriteLine($"\tCorrect Answer: " + questions[i].Correct);

            }
            Console.WriteLine();

            Console.WriteLine("\tChoose question that you want change");

          
            string exam = Console.ReadLine();
            Console.Clear();


            if (exam == "0")
            {
                Console.WriteLine("\tGoodBye Admin");
                return;
            }

            int.TryParse(exam, out int types);
            if (types <= 0 || types > questions.Count)
            {
                Console.WriteLine();
                Console.WriteLine("\tFalse choice,try again !!!");
                return;
            }

            Console.WriteLine();
            Console.Write("\tEnter the question Name: ");
            string questionname = Console.ReadLine();
            questions[types - 1].QuestionName = questionname;
            Console.Write("\tEnter the question's Answer A: ");
            string answerA = Console.ReadLine();
            questions[types - 1].AnswerA = answerA;
            Console.Write("\tEnter the question's Answer B: ");
            string answerB = Console.ReadLine();
            questions[types - 1].AnswerB = answerB;
            Console.Write("\tEnter the question's Answer C: ");
            string answerC = Console.ReadLine();
            questions[types - 1].AnswerC = answerC;
            Console.Write("\tEnter the question's Answer D: ");
            string answerD = Console.ReadLine();
            questions[types - 1].AnswerD = answerD;
            Console.Write("Enter correct answer: ");
            string correct = Console.ReadLine();
            questions[types - 1].Correct = correct.ToUpper();

            postUpdateQuestions(namesdicipline[types - 1],questions);

         

        }



    }
}

