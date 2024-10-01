
using Lab1_PRN231.Repository.Entities;
using Lab1_PRN231.Repository.ProductDbContext;

namespace Lab1_PRN231.Repository;

public class UnitOfWork : IDisposable
{
    private ProductContext context = new ProductContext();
    private GenericRepository<Category> _categories;
    private GenericRepository<Product> _productes;

    public GenericRepository<Category> Categories
    {
        get
        {
            if (this._categories == null)
            {
                this._categories = new GenericRepository<Category>(context);
            }
            return _categories;
        }
    }
    public GenericRepository<Product> Products
    {
        get
        {
            if (this._productes == null)
            {
                this._productes = new GenericRepository<Product>(context);
            }
            return _productes;
        }
    }
    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

