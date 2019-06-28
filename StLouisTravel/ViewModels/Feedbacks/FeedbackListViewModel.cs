using Microsoft.AspNetCore.Mvc.Rendering;
using StLouisTravel.Data;
using StLouisTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisTravel.ViewModels.Feedbacks
{
    public class FeedbackListViewModel
    {
        
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        public int LocationId { get; set; }
        //public Location Location { get; set; }
        //public SelectList Ratings { get { return GetRatings(); } }


        //public FeedbackListViewModel(int id, RepositoryFactory repositoryFactory)
        //{
        //    var rating = repositoryFactory.GetFeedbackRepository().GetById(id);
        //    var location = repositoryFactory.GetLocationRepository().GetById(rating.LocationId);
        //    this.Id = rating.Id;
        //    this.LocationId = rating.LocationId;
        //    //this.Location = location.Name;
        //    this.Rating = rating.Rating;
        //}

        //    private SelectList GetRatings()
        //    {
        //        var ratingSelectListItems = ratings.Select(r => new SelectListItem(r.ToString(), r.ToString(), this.Rating == r));
        //        return new SelectList(ratingSelectListItems);
        //    }
    }
}
