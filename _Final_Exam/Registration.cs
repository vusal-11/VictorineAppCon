using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Final_Exam
{
    internal class Registration
    {
        public void create()
        {
            
            User user = new User();
            user.getcredentials();
            Console.WriteLine();
            Console.Write("\tInsert your birthdate in format yyyy.m.d ");
            DateTime birthdate;
            DateTime.TryParse(Console.ReadLine(), out birthdate);
            user.BirthDate = birthdate;
            string path = @$"../../../../Users\\{user.Login}.json";
            if (!File.Exists(path))
            {
                var myfile = File.Create(path);

                myfile.Close();

                string users = JsonConvert.SerializeObject(user);

                using (StreamWriter writer = new StreamWriter(path))
                {

                    writer.WriteLine(users);
                    writer.Close();
                }
            }


        }
    }
}
