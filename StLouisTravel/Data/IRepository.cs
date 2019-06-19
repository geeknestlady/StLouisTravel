using StLouisTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisTravel.Data
{
    public interface IRepository
    {
            IModel GetById(int id);
            List<IModel> GetModels();
            int Save(IModel model);
            void Delete(int id);
            void Update(IModel model);
        
    }
}
