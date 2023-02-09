using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalLove.Shared.Domain
{
    public class Chat : BaseDomainModel, IValidatableObject
    {
        public string ChatMessage { get; set; }

        [Required(ErrorMessage = "Please select a user")]

        [ForeignKey("UserDetail1Id")]
        public int? UserDetail1Id { get; set; }

        public virtual UserDetail UserDetail1 { get; set; }


        [ForeignKey("UserDetail2Id")]
        public int? UserDetail2Id { get; set; }
        public virtual UserDetail UserDetail2 { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UserDetail1Id != null)
            {
                if (UserDetail1Id == UserDetail2Id)
                {
                    yield return new ValidationResult("User cannot be the same", new[] { "UserDetail2Id" });
                }

            }
        }
    }
}