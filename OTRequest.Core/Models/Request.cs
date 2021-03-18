using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTRequest.Core.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public string  User { get; set; }
        public string DepartmentName { get; set; }
        public string Status { get; set; }
        public string TotalRemarks { get; set; }
        public decimal TotalHours { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<DetailRequest> DetailRequests { get; set; }
    }
}
