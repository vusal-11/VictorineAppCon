using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Final_Exam
{
    internal class Results
    {
        

            public static VictorineResult GetResult(string fileName, string type)
            {
                VictorineResult result = new();
                using (StreamReader r = new StreamReader($"../../../../res{type}\\{fileName}.json"))
                {
                    string json = r.ReadToEnd();
                    result = JsonConvert.DeserializeObject<VictorineResult>(json);
                }
                return result;
            }

            public List<VictorineResult> GetTop20Results(string dir)
            {
                List<VictorineResult> result = new();
                FileLibrary fl = new FileLibrary();
                List<string> fileNames = fl.listFileNames(dir, "*.json");
                List<VictorineResult> results = new List<VictorineResult>();
                for (int i = 0; i < fileNames.Count; i++)
                {
                    VictorineResult item;
                    using (StreamReader r = new StreamReader($"../../../../{dir}\\{fileNames[i]}.json"))
                    {
                        string json = r.ReadToEnd();
                        item = JsonConvert.DeserializeObject<VictorineResult>(json);
                    }
                    result.Add(item);
                }

                List<VictorineResult> newRes = result.OrderBy(x => x.PointCount).Reverse().ToList();
                Console.WriteLine();
                for (int i = 0; i < newRes.Count; i++)
                {
                    Console.Write("\t"+fileNames[i] + "  -> ");
                    Console.WriteLine(newRes[i].PointCount + "  Points");
                }
                Console.WriteLine();

                return newRes;
            }




        
    }
}
