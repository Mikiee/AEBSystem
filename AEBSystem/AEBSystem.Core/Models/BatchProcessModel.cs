using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEBSystem.Core.Models
{
    public class BatchProcessModel
    {
        public string BatchNo { get; set; }
        public string Status { get; set; }
        public DateTime PendingDate { get; set; }
        public DateTime RecievedDate { get; set; }
    }
}
