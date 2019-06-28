using Microsoft.AspNetCore.Mvc;
using StLouisTravel.Data;
using StLouisTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace StLouisTravel.ViewModels.Locations
{
    public class DetailsLocationViewModels
    {
        public static DetailsLocationViewModels GetDetails(RepositoryFactory factory, int locationId)
        {
            DetailsLocationViewModels locationDetails = new DetailsLocationViewModels();
            Location location = factory.GetLocationRepository()
                .GetById(locationId);

            List<DetailsLocationViewModels> feedbackDetails = new DetailsLocationViewModels();

            //return factory.GetLocationRepository()
            //    .GetById(locationId)
            //    .Select(l => new DetailsLocationViewModels(l));



        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public List<DetailsLocationViewModels> Feedbacks { get; set; }
       

      
    }
}