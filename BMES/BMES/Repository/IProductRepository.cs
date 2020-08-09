using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Products;

namespace BMES.Repository
{
    public interface IProductRepository
    {
        Product FindProductById(long id);
        IEnumerable<Product> GetAllProducts();
        void SaveProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
