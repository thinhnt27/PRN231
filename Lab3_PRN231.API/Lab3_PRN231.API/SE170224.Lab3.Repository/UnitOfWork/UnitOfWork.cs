using Lab3_PRN231.Repository;
using Lab3_PRN231.Repository.Models;

namespace SE170224.PRN231.Repository.UnitOfWork;


public class UnitOfWork : IUnitOfWork
{
    private readonly Lab3Prn231Context _context;
    private GenericRepository<Category> _categories = null!;
    private GenericRepository<Product> _productes = null!;
    private GenericRepository<Account> _accounts = null!;

    public UnitOfWork(Lab3Prn231Context context)
    {
        _context = context;
    }

    public GenericRepository<Category> CategoriesRepository
    {
        get
        {
            _categories ??= new GenericRepository<Category>(_context);
            return _categories;
        }
    }

    public GenericRepository<Product> ProductsRepository
    {
        get
        {
            _productes ??= new GenericRepository<Product>(_context);
            return _productes;
        }
    }

    public GenericRepository<Account> AccountsRepository
    {
        get
        {
            _accounts ??= new GenericRepository<Account>(_context);
            return _accounts;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

