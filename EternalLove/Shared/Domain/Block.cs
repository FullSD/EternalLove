using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalLove.Shared.Domain
{
    public class Block : BaseDomainModel
    {
        public bool BlockUser { get; set; }
        public string MyProperty { get; set; }
        public int UserId { get; set; }
        public virtual UserDetail User { get; set; }

    }
}
