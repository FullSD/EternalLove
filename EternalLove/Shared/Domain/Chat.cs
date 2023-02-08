using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalLove.Shared.Domain
{
    public class Chat : BaseDomainModel
    {
        public string ChatMessage { get; set; }

        [Required(ErrorMessage = "Please select a user")]
        public int UserId { get; set; }
        public virtual UserDetail User { get; set; }

    }
}