using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OTRequest.Core.Models;

namespace OTRequest.MVC.ViewModels
{
    public class ClaimViewModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string DepartmentName { get; set; }
        public string Status { get; set; }
        public string TotalRemarks { get; set; }
        public decimal TotalHours { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<DetailRequest> DetailRequests { get; set; }
        public virtual List<DeverloperViewModel> Developers { get; set; }
    }
}