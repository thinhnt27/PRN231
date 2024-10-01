using Lab1_PRN231.Repository.Entities;
using Lab1_PRN231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_PRN231.Service.Service
{
    public class ProductService
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _unitOfWork.Products.GetAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task<bool> UpdateProductAsync(int id, Product product)
        {
            var productToUpdate = await _unitOfWork.Products.GetByIdAsync(id);
            if (productToUpdate == null) return false;

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryId = product.CategoryId;

            _unitOfWork.Products.Update(productToUpdate);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task InsertProductAsync(Product product)
        {
            await _unitOfWork.Products.InsertAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return false;

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> ProductExistsAsync(int id)
        {
            return await _unitOfWork.Products.IsExist(id);
        }
    }

}
