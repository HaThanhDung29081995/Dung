using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UowAndRepository.Interface;
using UowAndRepository.Models;

namespace UowAndRepository.Repository
{
    public class ProductRepository : IProductService
    {
        private DataContext _context;

        public ProductRepository(DataContext context)
        {
            this._context = context;
        }
        public void Delete(int Id)
        {
            
                Product product = _context.Products.Find(Id);
                _context.Products.Remove(product);
            
           
        }
        public List<Product> GetAllProduct()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int Id)
        {
            return _context.Products.Find(Id);
        }

        public void Insert(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }
        
    }
}