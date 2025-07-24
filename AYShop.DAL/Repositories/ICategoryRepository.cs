using AYShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYShop.DAL.Repositories
{
    public interface ICategoryRepository
    {
         IEnumerable<Category> GetAll(bool withTracking = false);
         Category? GetById(int id);
         int Add(Category category);
         int Update(Category category);
         int Remove(Category category);
    }
}
