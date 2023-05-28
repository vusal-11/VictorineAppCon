using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Final_Exam
{
    public class VictorineResult
    {
        public VictorineResult() { }
        public List<Answer> Answers { get; set; }

        public int PointCount { get; set; }
        public VictorineResult(List<Answer> answers, int point)
        {
            this.Answers = answers;
            this.PointCount = point;
        }

    }
}
