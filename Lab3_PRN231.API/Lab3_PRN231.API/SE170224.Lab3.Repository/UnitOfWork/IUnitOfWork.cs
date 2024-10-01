using Lab3_PRN231.Repository;
using Lab3_PRN231.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE170224.PRN231.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Category> CategoriesRepository { get; }
        GenericRepository<Product> ProductsRepository { get; }
        GenericRepository<Account> AccountsRepository { get; }
        Task<int> SaveAsync();
    }
}
