using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _Final_Exam
{


    public enum SearchUserResponses
    {
        FOUND,
        WRONGCREDENTIALS,
        NOTFOUND
    }
    public class User
    {
        public User() { }
        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime BirthDate { get; set; }

        public User(string login, string password, DateTime birthDate)
        {
            Login = login;
            Password = password;
            BirthDate = birthDate;
        }

        public SearchUserResponses FindUser(string login, string password)
        {
            FileLibrary fl = new FileLibrary();


            List<string> users = fl.listFileNames("Users", "*.json");

            bool found = false;
            for (int i = 0; i < users.Count; i++)
            {
                if (login == users[i])
                {
                    found = true;
                    break;
                }
            }



            User user = new User();
            if (found)
            {
                try
                {
                    using (StreamReader r = new StreamReader($"../../../../Users\\{login}.json"))
                    {
                        string json = r.ReadToEnd();

                        user = JsonConvert.DeserializeObject<User>(json);
                    }

                }
                catch
                { }
                if (user?.Password == password)
                {
                    found = true;
                    return SearchUserResponses.FOUND;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tUser Password is wrong ,try again !!!");
                    Console.WriteLine();
                    return SearchUserResponses.WRONGCREDENTIALS;
                }
            }
            else
            {

                return SearchUserResponses.NOTFOUND;
            }

        }

        public bool getcredentials()
        {
            Console.WriteLine();
            Console.Write("\tInsert your login: ");
            string login = Console.ReadLine();
            Console.Write("\tInsert your password: ");
            string password = Console.ReadLine();
            Console.WriteLine();


            
            if (login == "" || password == "")
            {

                Console.WriteLine("\tCurrent credentials are not valid, try again!!!");
                return false;
            }


            this.Login = login;
            this.Password = password;


            return true;
        }


    }


}
