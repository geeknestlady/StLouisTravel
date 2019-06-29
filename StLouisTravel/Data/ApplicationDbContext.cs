using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StLouisTravel.Models;
using StLouisTravel.ViewModels.Locations;
using StLouisTravel.ViewModels.Feedbacks;
using StLouisTravel.ViewModels.Categories;

namespace StLouisTravel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Location> Location { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryLocation> CategoryLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasIndex(m => m.Name)
                .IsUnique();
        }
        //public DbSet<StLouisTravel.ViewModels.Categories.CategoryListViewModel> CategoryListViewModel { get; set; }
        //public DbSet<StLouisTravel.ViewModels.Categories.CategoryCreateViewModel> CategoryCreateViewModel { get; set; }
        //public DbSet<StLouisTravel.ViewModels.Feedbacks.FeedbackCreateViewModel> FeedbackCreateViewModel { get; set; }
        //public DbSet<StLouisTravel.ViewModels.Locations.DetailsLocationViewModels> DetailsLocationViewModels { get; set; }
        //public DbSet<StLouisTravel.ViewModels.Locations.EditLocationViewModel> EditLocationViewModel { get; set; }
        //public DbSet<StLouisTravel.ViewModels.Locations.CreateLocationViewModel> CreateLocationViewModel { get; set; }
    }
}
