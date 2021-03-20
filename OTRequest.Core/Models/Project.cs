using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OTRequest.Core.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }
        [DisplayName("Start Date")]
        public DateTime DateStart { get; set; }
        [DisplayName("Start End")]
        public DateTime DateEnd { get; set; }

        public string ManagerId { get; set; }

        public string QAId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual ICollection<UserProjectMap> UserProjectMaps { get; set; }

        [ForeignKey("ProjectId")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
