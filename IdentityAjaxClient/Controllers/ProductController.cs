using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessObjects.Entities;

namespace IdentityAjaxClient.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Trả về view danh sách sản phẩm (bạn tự làm)
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View("~/Views/Product/CreateProduct.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            // ✅ Sử dụng HttpClient tên "ProductApi"
            var client = _httpClientFactory.CreateClient("ProductApi");

            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/products", content); // ❌ không hardcode full URL

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Không tạo được sản phẩm, vui lòng thử lại.");
                return View(product);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");

            var response = await client.GetAsync($"api/products/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var product = JsonSerializer.Deserialize<Product>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return View("~/Views/Product/UpdateProduct.cshtml", product);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var client = _httpClientFactory.CreateClient("ProductApi");

            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"api/products/{product.ProductId}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Không cập nhật được sản phẩm.");
            return View(product);
        }

    }
}
