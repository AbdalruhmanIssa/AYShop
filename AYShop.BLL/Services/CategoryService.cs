using AYShop.DAL.DTO.Requests;
using AYShop.DAL.DTO.Responses;
using AYShop.DAL.Models;
using AYShop.DAL.Repositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYShop.BLL.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IEnumerable<CategoryResponse> GetAllCategories()
        {
            var categories = categoryRepository.GetAll();
            return categories.Adapt<IEnumerable<CategoryResponse>>();
        }
        public CategoryResponse? GetCategoryById(int id)
        {
            var category = categoryRepository.GetById(id);
            return category is null ? null : category.Adapt<CategoryResponse>();
        }
        public int CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();
            return categoryRepository.Add(category);
        }

        public int DeleteCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category is null) return 0;

            return categoryRepository.Remove(category);
        }
        public int UpdateCategory(int id, CategoryRequest request)
        {
            var category = categoryRepository.GetById(id);
            if (category is null) return 0;

            category.Name = request.Name;
            return categoryRepository.Update(category);
        }

        public bool ToggleStatus(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category is null) return false;

            category.Status = category.Status == Status.Active ? Status.Inactive : Status.Active;
            categoryRepository.Update(category);
            return true;
        }

    }
}
