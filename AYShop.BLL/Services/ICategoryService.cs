using AYShop.DAL.DTO.Requests;
using AYShop.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYShop.BLL.Services
{
    public interface ICategoryService
    {
         IEnumerable<CategoryResponse> GetAllCategories();
        CategoryResponse? GetCategoryById(int id);
         int CreateCategory(CategoryRequest request);
         int DeleteCategory(int id);
         int UpdateCategory(int id, CategoryRequest request);
         bool ToggleStatus(int id);
    }
}
