using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StLouisTravel.Models;

namespace StLouisTravel.Data
{
    public class RepositoryFactory
    {
        private ApplicationDbContext context;

        public RepositoryFactory(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IRepository<Location> GetLocationRepository()
        {
            return new Repository<Location>(context);
        }
        public IRepository<Feedback> GetFeedbackRepository()
        {
            return new Repository<Feedback>(context);
        }
        public IRepository<Category> GetCategoryRepository()
        {
            return new Repository<Category>(context);
        }
        public IRepository<CategoryLocation> GetCategoryLocationRepository()
        {
            return new Repository<CategoryLocation>(context);
        }

    }

}
