using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _For_Admin
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
        {

        }

        //public List<JsonArray> Geography;
        //public List<JsonArray> Soccer;
        //public List<JsonArray> IQ;


        ////

        //    using System.Text.Json;

        //Person tom = new Person("Tom", 37);
        //string json = JsonSerializer.Serialize(tom);
        //Console.WriteLine(json);
        //Person? restoredPerson = JsonSerializer.Deserialize<Person>(json);
        //Console.WriteLine(restoredPerson?.Name); // Tom

        //class Person
        //{
        //    public string Name { get; }
        //    public int Age { get; set; }
        //    public Person(string name, int age)
        //    {
        //        Name = name;
        //        Age = age;
        //    }
        //}





        ///////// 
        ///
        //    using System.Text.Json;

        //// сохранение данных
        //using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        //{
        //    Person tom = new Person("Tom", 37);
        //    await JsonSerializer.SerializeAsync<Person>(fs, tom);
        //    Console.WriteLine("Data has been saved to file");
        //}

        //// чтение данных
        //using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        //{
        //    Person? person = await JsonSerializer.DeserializeAsync<Person>(fs);
        //    Console.WriteLine($"Name: {person?.Name}  Age: {person?.Age}");
        //}

        //class Person
        //{
        //    public string Name { get; }
        //    public int Age { get; set; }
        //    public Person(string name, int age)
        //    {
        //        Name = name;
        //        Age = age;
        //    }
        //}





        //////


        /// <summary>
        /// //
        /// </summary>
        //public string Text { get; set; }

        //        public List<Answer> Answers;
        //        public override string ToString()
        //        {
        //            return $"{Text}:" +
        //                $"\nA){Answers[0]}" +
        //                $"\nB){Answers[1]}" +
        //                $"\nC){Answers[2]}" +
        //                $"\nD){Answers[3]}";
        //        }




    }
}

