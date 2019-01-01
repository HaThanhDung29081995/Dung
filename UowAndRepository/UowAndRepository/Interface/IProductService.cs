using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UowAndRepository.Models;

namespace UowAndRepository.Interface
{
    public interface IProductService
    {
        List<Product> GetAllProduct();
        void Insert(Product product);
        void Update(Product product);
        void Delete(int Id);
        Product GetProductById(int Id);
    }
}
