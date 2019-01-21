using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEBSystem.Core.Models;

namespace AEBSystem.Core.ViewModels
{
    public class HistoryViewModel
    {
        public IEnumerable<ExamHistoryResult> History {get; set;}
        public IEnumerable<tblLicType2> Subject { get; set; }
    }
}
