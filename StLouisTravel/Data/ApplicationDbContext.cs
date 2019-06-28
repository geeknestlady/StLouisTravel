using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StLouisTravel.Models;
using StLouisTravel.ViewModels.Locations;
using StLouisTravel.ViewModels.Feedbacks;

namespace StLouisTravel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Location> Location { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<StLouisTravel.ViewModels.Feedbacks.FeedbackCreateViewModel> FeedbackCreateViewModel { get; set; }
        //public DbSet<StLouisTravel.ViewModels.Locations.CreateLocationViewModel> CreateLocationViewModel { get; set; }
    }
}
