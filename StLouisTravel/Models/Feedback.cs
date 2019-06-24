using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisTravel.Models
{
    public class Feedback : IModel
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
