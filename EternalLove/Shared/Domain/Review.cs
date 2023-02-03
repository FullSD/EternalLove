using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalLove.Shared.Domain
{
    public class Review : BaseDomainModel
    {
        public string ReviewText { get; set; }
        public int Stars { get; set; }
        public int UserId { get; set; }
        public virtual UserDetail User{ get; set; }
    }
}