using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisTravel.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
    }
}
