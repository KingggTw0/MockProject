using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTRequest.Core.Models
{
    public class DetailRequest
    {
        public int Id { get; set; }
        public DateTime StartRequestDate { get; set; }
        public DateTime EndRequestDate { get; set; }
        public DateTime RequestDay { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Remark { get; set; }
        public decimal TotalHours { get; set; }
        public int RequestId { get; set; }
        public virtual Request Request { get; set; }
    }
}
