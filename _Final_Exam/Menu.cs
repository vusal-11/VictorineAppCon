using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Final_Exam
{
    internal class Menu
    {
        public void Welcome()
        {
            bool action = true;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\tWelcome to The Victorine App");
            Console.WriteLine();

            while (action)
            {
                User user = new User();

                while (true)
                {


                    if (!user.getcredentials())
                    {
                        Console.WriteLine("\tTry again");

                    }
                    else break;

                }
                Console.Clear();

                SearchUserResponses found = user.FindUser(user.Login, user.Password);

                switch (found)
                {
                    case SearchUserResponses.FOUND:
                        TakeExam(user);
                        break;
                    case SearchUserResponses.WRONGCREDENTIALS:
                        continue;
                        break;
                    case SearchUserResponses.NOTFOUND:
                        Console.WriteLine("\tUser not found !!!");
                        Console.WriteLine();
                        Console.WriteLine("\tTo Login with another user name press -> 1 ");
                        Console.WriteLine("\tTo Register  press -> 2 ");
                        string ch = Console.ReadLine();
                        Console.Clear();

                        if (ch == "1")
                        {
                            continue;
                        }
                        else if (ch == "2")
                        {
                            Registration registration = new Registration();
                            registration.create();
                            TakeExam(user);

                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("\tFalse input try again");
                            Console.WriteLine();
                            continue;
                        }


                        break;
                    default:
                        break;
                }




            }

        }

        public void TakeExam(User user)
        {
            Victorine victorine = new Victorine();

            Console.WriteLine();
            Console.WriteLine("\tHello  " + user.Login + " !");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("\tChoose Option");
                Console.WriteLine();
                Console.WriteLine("\tFor start new Victorine press - > press 1");
                Console.WriteLine("\tFor look your last results -> press 2");
                Console.WriteLine("\tFor look top 20 for single victorine -> press 3");
                Console.WriteLine("\tFor change password or birthdate -> press 4");
                Console.WriteLine("\tFor exit App -> press 0");
                Console.WriteLine();
                string choice = Console.ReadLine();
                Console.Clear();

                if (choice == "1")
                    victorine.StartVicroine(user);
                    Console.WriteLine();
                if (choice == "2")
                {
                    Console.WriteLine();
                    Console.WriteLine("\tChoose in which discipline you want to know result");

                    


                    List<string> questionFileNames = victorine.getQuestionFileNames();
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
                        Console.WriteLine("\tFalse choice,try again !!!");
                        return;
                    }


                    VictorineResult result = new();
                    try
                    {
                        result = Results.GetResult(user.Login, questionFileNames[type - 1]);

                    }
                    catch (Exception)
                    {

                        Console.WriteLine("\tYou haven't passed  victorine yet");
                        Console.WriteLine();
                        continue;
                    }

                        Console.WriteLine("--------------------------------------------------------------");
                    for (int i = 0; i < result.Answers.Count; i++)
                    {
                        Console.WriteLine("\t" + result.Answers[i].QuestionName);
                        Console.WriteLine();
                        Console.WriteLine($"\tUser Answer {result.Answers[i].UserAnswer}");
                        Console.WriteLine($"\tCorrect answer: {result.Answers[i].Correct}");
                        Console.WriteLine("---------------------------------------------------------------");
                    }
                    Console.WriteLine("===========================================================");
                    Console.WriteLine($"\tTotal Count of correct answers is: {result.PointCount}");
                    Console.WriteLine("===========================================================");
                    Console.WriteLine();


                }

                if (choice == "3")
                {
                    Results results = new Results();

                    List<string> resultFileNames = victorine.getQuestionFileNames();
                    Console.WriteLine();
                    for (int i = 0; i < resultFileNames.Count; i++)
                    {
                        Console.WriteLine($"\tFor Questions by {resultFileNames[i]} press -> {i + 1}");
                    }
                    Console.WriteLine("\tFor exit press any 0");
                    Console.WriteLine();

                    int type = 0;
                    bool disciplineChosen = false;

                    while (!disciplineChosen)
                    {
                        string x = Console.ReadLine();
                        if (x == "0") break;

                        int.TryParse(x, out type);
                        if (type <= 0 || type > resultFileNames.Count)
                        {
                            
                            Console.Clear();

                            Console.WriteLine("\tFalse choice,try again !!!");
                            Console.WriteLine();
                            break;
                        }

                        disciplineChosen = true;

                    }
                    try
                    {
                        Results.GetResult(user.Login, resultFileNames[type - 1]);
                        results.GetTop20Results("res" + resultFileNames[type - 1]);
    

                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("\tNobody pass this Victorine yet!!!");
                    }

                       
                        

                }

                if (choice == "4")
                {


                    using (StreamReader r = new StreamReader($"../../../../Users\\{user.Login}.json"))
                    {
                        string json = r.ReadToEnd();
                        user = JsonConvert.DeserializeObject<User>(json);
                        Console.WriteLine();
                        Console.WriteLine($"\tPassword is ->   {user.Password}");
                        string updatetime = user.BirthDate.ToShortDateString();
                        Console.WriteLine($"\tBirthdate is -> {updatetime}");
                        r.Close();
                        Console.WriteLine();
                        Console.WriteLine("\tIf you want change password press -> 1");
                        Console.WriteLine("\tIf you want change birthdate press -> 2");
                        string choices = Console.ReadLine();

                        if (choices == "1")
                        {


                            string path = @$"../../../../Users\\{user.Login}.json";
                            if (File.Exists(path))
                            {
                                Console.WriteLine();
                                Console.Write("\tEnter new Password: ");
                                string ps = Console.ReadLine();
                                user.Password = ps;
                                string users = JsonConvert.SerializeObject(user);

                                using (StreamWriter writer = new StreamWriter(path))
                                {

                                    writer.WriteLine(users);
                                    writer.Close();
                                }
                                Console.WriteLine();
                                Console.WriteLine("\tPassword changed succesfully");
                            }
                        }
                        if (choices == "2")
                        {

                            Console.WriteLine();
                            Console.Write("\tInsert your new birthdate in format yyyy.m.d : ");
                            DateTime birthdate;
                            DateTime.TryParse(Console.ReadLine(), out birthdate);
                            user.BirthDate = birthdate;

                            string path = @$"../../../../Users\\{user.Login}.json";
                            if (File.Exists(path))
                            {
                                user.BirthDate = birthdate;
                                string users = JsonConvert.SerializeObject(user);


                                using (StreamWriter writer = new StreamWriter(path))
                                {

                                    writer.WriteLine(users);
                                    writer.Close();
                                }
                                Console.WriteLine(Console.Clear);
                                Console.WriteLine();
                                Console.WriteLine("\tBirthDate changed succesfully!!!");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\tFalse choice!!!");
                        }

                    }

                }
                if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "0")
                {
                    Console.WriteLine();
                    Console.WriteLine("\tFalse choice,this operation doesn't exist, try again!!!");
                    Console.WriteLine();
                }
                if (choice == "0") break;

            }
        }

    }
}

