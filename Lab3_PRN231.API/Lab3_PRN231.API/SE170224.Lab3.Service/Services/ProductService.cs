using Lab3_PRN231.Repository.Models;
using Lab3_PRN231.Service.BusinessModel;
using Lab3_PRN231.Service.BusinessModels;
using Microsoft.EntityFrameworkCore;
using SE170224.PRN231.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_PRN231.Service.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductModel> CreateProductAsync(ProductModel product)
        {
            var categoryExists = await _unitOfWork.CategoriesRepository.IsExist(product.CategoryId);
            if (!categoryExists)
            {
                throw new Exception($"Category {product.CategoryId} not found");
            }

            var newProduct = new Product()
            {
                Name = product.ProductName,
                UnitsInStock = product.UnitsInStock,
                UnitPrice = product.UnitPrice,
                CategoryId = product.CategoryId
            };
            await _unitOfWork.ProductsRepository.InsertAsync(newProduct);
            await _unitOfWork.SaveAsync();
            product.ProductId = newProduct.Id;

            return product;
        }

        public async Task<ProductModel?> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductsRepository.GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }

            return new ProductModel()
            {
                ProductId = product.Id,
                ProductName = product.Name,
                UnitsInStock = product.UnitsInStock,
                UnitPrice = product.UnitPrice,
                CategoryId = product.CategoryId
            };
        }

        public async Task<ProductsModel> GetProductsAsync(int pageIndex, int pageSize, string search, string orderBy, bool orderDesc)
        {
            IQueryable<Product> query = _unitOfWork.ProductsRepository.GetQueryable().Include(p => p.Category);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.ToLower().Contains(search.ToLower()));
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                if (orderDesc)
                {
                    query = query.OrderByDescending(p => EF.Property<object>(p, orderBy));
                }
                else
                {
                    query = query.OrderBy(p => EF.Property<object>(p, orderBy));
                }
            }

            var total = await query.CountAsync();

            var products = await query
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var productResponses = products.Select(p => new ProductModel
            {
                ProductId = p.Id,
                ProductName = p.Name,
                UnitsInStock = p.UnitsInStock,
                UnitPrice = p.UnitPrice,
                CategoryId = p.Category != null ? p.Category.Id : 0
            }).ToList();

            var result = new ProductsModel(productResponses, total, pageIndex, pageSize);


            return result;
        }

        public async Task<ProductModel> UpdateProductAsync(int productId, ProductModel productModel)
        {
            var product = await _unitOfWork.ProductsRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new Exception($"Product {productId} not found");
            }

            product.Name = productModel.ProductName;
            product.UnitsInStock = productModel.UnitsInStock;
            product.UnitPrice = productModel.UnitPrice;
            product.CategoryId = productModel.CategoryId;

            await _unitOfWork.ProductsRepository.Update(product);
            await _unitOfWork.SaveAsync();
            return new ProductModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                UnitsInStock = product.UnitsInStock,
                UnitPrice = product.UnitPrice,
                CategoryId = product.CategoryId
            };
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _unitOfWork.ProductsRepository.GetByIdAsync(productId);
            if (product == null)
            {
                return false;
            }

            await _unitOfWork.ProductsRepository.Delete(product);
            await _unitOfWork.SaveAsync();

            return true;
        }
        public async Task<IEnumerable<ProductModel>> GetProductsByIdsAsync(IEnumerable<int> ids)
        {
            var product = await _unitOfWork.ProductsRepository.GetByIdsAsync(ids.Cast<object>());
            return product.Select(p => new ProductModel
            {
                ProductId = p.Id,
                ProductName = p.Name,
                UnitsInStock = p.UnitsInStock,
                UnitPrice = p.UnitPrice,
                CategoryId = p.CategoryId
            });
        }
        public async Task<bool> ProductExistsAsync(int id)
        {
            return await _unitOfWork.ProductsRepository.IsExist(id);
        }


    }
}
