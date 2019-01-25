using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEBSystem.Core.Models
{
     public class ExamHistoryResultClone
    {
        public string airmen_name { get; set; }
        public string Subject { get; set; }
        public string PassFail { get; set; }
        public double Rating { get; set; }
        public string exam_date { get; set; }
        public int Applicant_id { get; set; }
        public int Correct_Ans { get; set; }
        public int No_Items { get; set; }
        public string Loc { get; set; }
        public int Subject_ID { get; set; }
        public string License { get; set; }
        public string PEL { get; set; }
    }
}
