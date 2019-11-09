using System;
namespace pcsHackathon2019.Models
{
    public class Allowance
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public virtual Budget Budget { get; set; }
    }
}
