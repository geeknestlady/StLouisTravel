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
        public string Region { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual List<Feedback> Ratings { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}
