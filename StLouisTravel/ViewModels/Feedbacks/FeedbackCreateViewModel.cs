using Microsoft.AspNetCore.Mvc.Rendering;
using StLouisTravel.Data;
using StLouisTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisTravel.ViewModels.Feedbacks
{
    public class FeedbackCreateViewModel
    {
        private string ratings = "12345";
        private readonly RepositoryFactory repositoryFactory;

        public int Rating { get; set; }
        public string Review { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
        public SelectList Ratings { get { return GetRatings(); } }

        public FeedbackCreateViewModel(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        private SelectList GetRatings()
        {
            var ratingSelectListItems = ratings.Select(r => new SelectListItem(r.ToString(), r.ToString()));
            return new SelectList(ratingSelectListItems);
        }

        internal void Persist()
        {
            Feedback rating = new Feedback
            {
                LocationId = this.LocationId,
                Rating = this.Rating
            };
            repositoryFactory.GetFeedbackRepository().Save(rating);
        }
    }
}

