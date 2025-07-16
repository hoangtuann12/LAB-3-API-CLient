using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Entities;
using DataAccess.DAO;
using Repositories.Repositories.Interface;

namespace Repositories.Repositories.Implement
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO _productDao;

        public ProductRepository(ProductDAO productDao)
        {
            _productDao = productDao;
        }

        public void DeleteProduct(Product product) => _productDao.DeleteProduct(product);
        public void SaveProduct(Product product) => _productDao.SaveProduct(product);
        public void UpdateProduct(Product product) => _productDao.UpdateProduct(product);
        public List<Product> GetAllProducts() => _productDao.GetProducts();
        public Product GetProductById(int productId) => _productDao.FindProductById(productId);
        public List<Category> GetAllCategories() => new List<Category>(); // tạm bỏ nếu chưa cần
    }

}
