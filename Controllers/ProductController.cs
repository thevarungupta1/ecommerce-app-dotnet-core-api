using ecommerce_web_api.Models;
using ecommerce_web_api.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var data = _productService.GetProducts();
            return Ok(data);
        }

        [HttpGet("category/{catId}")]
        public ActionResult<List<Product>> GetProductsByCatId(int catId)
        {
            var data = _productService.GetProductByCatId(catId);
            if(data == null)
                return NotFound("no product found with catId: "+ catId);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult<List<Product>> GetProductById(int id)
        {
            var data = _productService.GetProductById(id);
            if(data == null)
                return NotFound("no product found with product id: " + id);
            return Ok(data);
        }

        [HttpPost("{catId}")]
        public ActionResult<Product> PostProduct(int catId, Product product) 
        { 
            var data = _productService.AddProduct(catId, product);
            return Ok(data);
        }
    }
}
