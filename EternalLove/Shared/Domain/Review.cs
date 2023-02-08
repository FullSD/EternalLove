using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EternalLove.Shared.Domain
{
    public class Review : BaseDomainModel
    {

        public string ReviewText { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Stars { get; set; }

        [Required(ErrorMessage = "Please select a user")]
        public int UserId { get; set; }
        public virtual UserDetail User{ get; set; }
    }
}