using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataBookStore.Model;

namespace ODataBookStore.Controllers
{
    public class PressesController : ODataController
    {
        private BookStoreContext _dbContext;

        public PressesController(BookStoreContext dbContext)
        {
            _dbContext = dbContext;

            if (dbContext.Books.Count() == 0)
            {
                foreach (var book in DataSource.GetBooks())
                {
                    dbContext.Books.Add(book);
                    dbContext.Presss.Add(book.Press);
                }
                dbContext.SaveChanges();
            }
        }

        //(MaxExpansionDepth = 0)
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_dbContext.Presss);
        }
    }
}
