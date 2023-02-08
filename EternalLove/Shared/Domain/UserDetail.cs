using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalLove.Shared.Domain
{
    public class UserDetail : BaseDomainModel
    {
        [Required(ErrorMessage = "Please type in your name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet length requirements")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a gender")]
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public string PhotoLink { get; set; }
        public string Bio { get; set; }

        [Required(ErrorMessage = "Please select a location")]
        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }

        public string Perferance { get; set; }


    }

}
