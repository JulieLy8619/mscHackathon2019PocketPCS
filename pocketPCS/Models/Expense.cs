using System;
using System.ComponentModel.DataAnnotations;

namespace pcsHackathon2019.Models
{
    public class Expense
    {
        [Key]
        public string Name { get; set; }
        public double Cost { get; set; }
        public virtual Budget Budget { get; set; }
    }
}
