using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _For_Admin
{
    public class Admin
    {

        public void Run()
        {
            while (true)
            {

                Console.WriteLine("\tApp for Admin");
                Console.WriteLine("\tFor entering press -> 1");
                Console.WriteLine("\tFor exit app press -> 0");
                string options=(Console.ReadLine());
                if (options == "1")
                {

                    Console.WriteLine();
                    Console.Write("\tEnter login: ");

                    string log = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("\tEnter password: ");
                    string password = Console.ReadLine();
                    bool op = false;
                    if (log == "admin" && password == "admin")
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tHello Admin");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("\tUncorrect entering credentials, try again");
                        Console.WriteLine();
                        continue;
                    }
                    Console.WriteLine();
                    Console.WriteLine("\tFor create new victorine and questions press -> 1 ");
                    Console.WriteLine("\tFor change old questions press -> 2 ");
                    Console.WriteLine("\tFor exit press - > 0");

                    string option = Console.ReadLine();

                    ManageVictorine manage = new();

                    if (option == "1")
                    {
                        manage.createVictorine();
                    }
                    if (option == "2")
                    {
                        manage.ChangeVictorine();

                    }
                }
                if(options == "0")break;
                if(options != "1" && options!= "0")
                {
                    Console.Clear();
                    Console.WriteLine("\tFalse choice,try again!!!");
                    continue;
                }
            }


        }
    }
}
