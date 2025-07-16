using BusinessObjects.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repositories.Implement;
using Repositories.Repositories.Interface;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")] // ✅ Sửa chỗ này
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProduct() => productRepository.GetAllProducts();

        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            productRepository.SaveProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")] // ✅ Sửa route: dùng {id} thay vì "id"
        public IActionResult DeleteProduct(int id)
        {
            var product = productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            productRepository.DeleteProduct(product);
            return NoContent();
        }

        [HttpPut("{id}")] // ✅ Sửa route: dùng {id} thay vì "id"
        public IActionResult UpdateProduct(int id, Product product)
        {
            var existingProduct = productRepository.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            productRepository.UpdateProduct(product);
            return NoContent();
        }
    }
}
