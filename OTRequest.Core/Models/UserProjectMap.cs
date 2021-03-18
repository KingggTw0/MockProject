using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTRequest.Core.Models
{
    public class UserProjectMap
    {
        [Key]
        [Column(Order = 1)]
        public int ProjectId { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(128)]
        public string UserId { get; set; }

    }
}
