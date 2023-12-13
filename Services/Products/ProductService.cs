using ecommerce_web_api.Database;
using ecommerce_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_web_api.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;

        public ProductService(DatabaseContext context)
        {
            _context = context;
        }

        public Product AddProduct( int catId, Product product)
        {
            // find the category by catId
            Category category = _context.Categories.FirstOrDefault(cat => cat.CategoryId == catId);
            // set category for the product
            product.Category = category;
            // add new product
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public List<Product> GetProductByCatId(int catId)
        {
            return _context.Products.Where(x => x.Category.CategoryId == catId).Include(x => x.Category).ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Where(x => x.ProductId == id).Include(x => x.Category).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            // include is used to create a join statement to fetch data from category table based on common col
            return _context.Products.Include(c => c.Category).ToList();
        }
    }
}
