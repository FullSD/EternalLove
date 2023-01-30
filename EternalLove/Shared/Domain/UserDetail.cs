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
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Last Name does not meet length requirements")]
        public string Name { get; set; }

        [Required]
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public string PhotoLink { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public string Perferance { get; set; }


    }

}
