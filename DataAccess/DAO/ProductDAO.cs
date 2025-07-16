using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Data;
using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    //    public class ProductDAO
    //    {
    //        public static List<Product> GetProducts()
    //        {
    //            var listProducts = new List<Product>();
    //            try
    //            {
    //                using (var context = new MyDbContext())
    //                {

    //                    listProducts = context.Products
    //                        .Include(p => p.Category) 
    //                        .ToList();
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                // Log exception nếu cần
    //                throw new Exception("An error occurred while retrieving products.", ex);
    //            }
    //            return listProducts;
    //        }

    //        public static Product FindProductById (int productId)
    //        {
    //            Product product = null;
    //            try
    //            {
    //                using (var context = new MyDbContext())
    //                {
    //                    product = context.Products.SingleOrDefault(p => p.ProductId == productId);
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                // Log the exception (not implemented here)
    //                throw new Exception("An error occurred while retrieving the product.", ex);
    //            }
    //            return product;
    //        }
    //        public static void SaveProduct(Product product)
    //        {
    //            try
    //            {
    //                using (var context = new MyDbContext())
    //                {
    //                    context.Products.Add(product);
    //                    context.SaveChanges();
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                // Log the exception (not implemented here)
    //                throw new Exception("An error occurred while adding the product.", ex);
    //            }
    //        }
    //        public static void UpdateProduct(Product product)
    //        {
    //            try
    //            {
    //                using (var context = new MyDbContext())
    //                {
    //                    context.Entry<Product>(product).State = 
    //                        Microsoft.EntityFrameworkCore.EntityState.Modified;
    //                    context.SaveChanges();
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                // Log the exception (not implemented here)
    //                throw new Exception("An error occurred while updating the product.", ex);
    //            }
    //        }
    //        public static void DeleteProduct(Product product)
    //        {
    //            try
    //            {
    //                using (var context = new MyDbContext())
    //                {
    //                    context.Products.Remove(product);
    //                    context.SaveChanges();
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                // Log the exception (not implemented here)
    //                throw new Exception("An error occurred while deleting the product.", ex);
    //            }
    //        }


    //        }
    //}
    public class ProductDAO
    {
        private readonly MyDbContext _context;

        public ProductDAO(MyDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products
                           //.Include(p => p.Category)
                           .ToList();
        }

        public Product FindProductById(int productId)
        {
            return _context.Products.SingleOrDefault(p => p.ProductId == productId);
        }

        public void SaveProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}