using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalLove.Shared.Domain
{
    public class Report : BaseDomainModel
    {
        [Required(ErrorMessage = "Please state bug found")]
        public string ReportBugs { get; set; }

        [Required(ErrorMessage = "Please select a user")]
        public int? UserId { get; set; }
        public virtual UserDetail User { get; set; }

    }
}