using System;
using System.Collections.Generic;

namespace pcsHackathon2019.Models
{
    public class Thread
    {
        public int ThreadID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Comment> Comments { get; }
    }
}
