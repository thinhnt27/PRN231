using Lab1_PRN231.Repository.Entities;
using Lab1_PRN231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_PRN231.Service.Service
{
    public class CategoryService
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoryService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _unitOfWork.Categories.GetAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _unitOfWork.Categories.GetByIdAsync(id);
        }

        public async Task InsertCategoryAsync(Category category)
        {
            await _unitOfWork.Categories.InsertAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category category)
        {
            var categoryToUpdate = await _unitOfWork.Categories.GetByIdAsync(id);
            if (categoryToUpdate == null) return false;

            categoryToUpdate.CategoryName = category.CategoryName;

            _unitOfWork.Categories.Update(categoryToUpdate);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null) return false;

            _unitOfWork.Categories.Delete(category);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> CategoryExistsAsync(int id)
        {
            return await _unitOfWork.Categories.IsExist(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int id)
        {
            return await _unitOfWork.Products.GetAsync(p => p.CategoryId == id);
        }
    }

}
