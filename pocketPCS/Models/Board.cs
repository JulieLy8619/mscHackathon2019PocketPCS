using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pcsHackathon2019.Models
{
    public class Board
    {
        [Key]
        public string Name { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Thread> Threads { get; }
    }
}
