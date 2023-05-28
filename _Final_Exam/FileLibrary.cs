using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Final_Exam
{
    internal class FileLibrary
    {

        public List<string> listFileNames(string dirName, string extention)
        {
            DirectoryInfo d = new DirectoryInfo("../../../../"+dirName); //Assuming Test is your Folder

            FileInfo[] Files = d.GetFiles(extention); //Getting Text files

            List<string> fileNames = new List<string>();
            foreach (FileInfo file in Files)
            {
                fileNames.Add(file.Name.Replace(".json", ""));
            }

            return fileNames;
        }



        public User GetUser(string fileName)
        {
            User user = new User();
            using (StreamReader r = new StreamReader($"../../../../Users\\{fileName}.json"))
            {
                string json = r.ReadToEnd();

                user = JsonConvert.DeserializeObject<User>(json);
            }
            return user;
        }



        public List<Question> GetQuestions(string fileName)
        {
            List<Question> questions = new List<Question>();
            using (StreamReader r = new StreamReader($"../../../../Questions\\{fileName}.json"))
            {
                string json = r.ReadToEnd();
                questions = JsonConvert.DeserializeObject<List<Question>>(json);
            }
            return questions;
        }


        public void getFilesNames()
        {
            try
            {
                // Only get files that begin with the letter "c".
                string[] dirs = Directory.GetFiles("../../../../Users");
                Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public void PostAnswers(string fileName, Victorine victorine, string dir)
        {
            
            string path = @$"../../../../{dir}\\{fileName}.json";
            VictorineResult result = new(victorine.Answers, victorine.PointCount);
            if (!File.Exists(path))
            {
                var myfile = File.Create(path);

                myfile.Close();
                string strAnswers = JsonConvert.SerializeObject(result);

                using (StreamWriter writer = new StreamWriter(path))
                {

                    writer.WriteLine(strAnswers);
                    writer.Close();
                }
            }
            else
            {
                File.Delete(path);

                var myfile = File.Create(path);

                myfile.Close();
                string strAnswers = JsonConvert.SerializeObject(result);

                using (StreamWriter writer = new StreamWriter(path))
                {

                    writer.WriteLine(strAnswers);
                    writer.Close();
                }

            }
        }

    }
}
