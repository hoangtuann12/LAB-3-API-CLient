using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Entities;

namespace Repositories.Repositories.Interface
{
    public interface IProductRepository
    {
        void SaveProduct(Product product);
        Product GetProductById(int productId);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        List<Product> GetAllProducts();
        List<Category> GetAllCategories();

    }
}
