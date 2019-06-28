using Microsoft.AspNetCore.Mvc;
using StLouisTravel.Data;
using StLouisTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using StLouisTravel.ViewModels.Feedbacks;

namespace StLouisTravel.ViewModels.Locations
{
    public class DetailsLocationViewModels
    {
        public static DetailsLocationViewModels GetDetails(RepositoryFactory factory, int id)
        {
            
            Location location = factory.GetLocationRepository()
                .GetById(id);

            List<Feedback> feedbackDetails = factory.GetFeedbackRepository()
                .GetModels()
                .Where(f => f.LocationId == id)
                .ToList();

            List<FeedbackListViewModel> feedbackDetailsViewModel = new List<FeedbackListViewModel>();

            foreach(Feedback feedbackDetail in feedbackDetails)
            {
                FeedbackListViewModel feedbacks = new FeedbackListViewModel();
                feedbacks.Rating = feedbackDetail.Rating;
                feedbacks.Review = feedbackDetail.Review;
                feedbackDetailsViewModel.Add(feedbacks);
            }
            return new DetailsLocationViewModels()
            {
                Name = location.Name,
                Address = location.Address,
                Description = location.Description,
                Id = location.Id,
                Feedbacks = feedbackDetailsViewModel
            };

            //return factory.GetLocationRepository()
            //    .GetById(locationId)
            //    .Select(l => new DetailsLocationViewModels(l));



        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public virtual List<FeedbackListViewModel> Feedbacks { get; set; }
       

      
    }
}