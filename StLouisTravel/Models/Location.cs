using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisTravel.Models
{
    public class Location : IModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public IList<Feedback> Ratings { get; set; }
    }
}
