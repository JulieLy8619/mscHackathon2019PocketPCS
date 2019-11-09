using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pocketPCS.Models
{
    public class AdditionalCost
    {
        public int ID { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public double Amount { get; set; }
        public string ItemDescription { get; set; }
    }
}
