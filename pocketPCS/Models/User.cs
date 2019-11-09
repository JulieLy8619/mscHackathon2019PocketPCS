using pcsHackathon2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pocketPCS.Models
{
    public class User
    {
        public string Id { get; set; }

        public ICollection<Move> Moves; 
    }
}
