using System;
using System.Collections.Generic;

namespace pcsHackathon2019.Models
{
    public class Board
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Thread> Threads { get; }
    }
}
