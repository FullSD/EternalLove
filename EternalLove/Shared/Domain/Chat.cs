using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("UserDetail1Id")]
        public int? UserDetail1Id { get; set; }

        public virtual UserDetail UserDetail1 { get; set; }


        [ForeignKey("UserDetail2Id")]
        public int? UserDetail2Id { get; set; }
        public virtual UserDetail UserDetail2 { get; set; }
    }
}