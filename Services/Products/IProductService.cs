using ecommerce_web_api.Models;

namespace ecommerce_web_api.Services.Products
{
    public interface IProductService
    {
        List<Product> GetProducts();
        List<Product> GetProductByCatId(int catId);
        Product GetProductById(int id);
        Product AddProduct(int catId, Product product);
    }
}
