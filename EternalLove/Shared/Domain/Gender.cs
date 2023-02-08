using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalLove.Shared.Domain
{
    public class Gender : BaseDomainModel
    {
        [Required(ErrorMessage = "Please type in gender")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Gender does not meet length requirements")]
        public string Name { get; set; }
    }
}
    