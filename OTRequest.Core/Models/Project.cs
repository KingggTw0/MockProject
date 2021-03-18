using System;
using System.Collections.Generic;
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
        public string ProjectName { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        [Required]
        public int ManageId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual ICollection<UserProjectMap> UserProjectMaps { get; set; }
        [ForeignKey("ProjectId")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
