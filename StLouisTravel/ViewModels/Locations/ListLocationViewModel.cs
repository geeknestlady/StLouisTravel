using Microsoft.AspNetCore.Mvc;
using StLouisTravel.Data;
using StLouisTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StLouisTravel.ViewModels.Locations
{
    public class ListLocationViewModel
    {
        public static List<ListLocationViewModel> GetLocations(RepositoryFactory factory)
        {
            return factory.GetLocationRepository()
                .GetModels()
                //.Include(m => m.Ratings)
                .Select(m => new ListLocationViewModel(m))
                .ToList();
           
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }        
        public string Description { get; set; }
        public double AverageRating { get; set; }
        public int NumberOfRatings { get; set; }

        public ListLocationViewModel(Location location)
        {
            this.Id = location.Id;
            this.Name = location.Name;
            this.Address = location.Address;
            this.Description = location.Description;
            if (location.Ratings.Count() == 0)
            {
                this.AverageRating = 0;
            }
            else
            {
                this.AverageRating = Math.Round(location.Ratings.Average(x => x.Rating));
            }
                //this.AverageRating = location.Ratings.Count >= 0 ? Math.Round(location.Ratings.Average(x => x.Rating), 2).ToString() : "none";
                this.NumberOfRatings = location.Ratings.Count;
        }
    }
}
