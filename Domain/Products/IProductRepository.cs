using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Products;

namespace Domain.Products;
public interface IProductRepository
{
    Task<Product?> GetByIdAsync(ProductId id);
    void Add(Product product);
    void Update(Product product);
    void Remove(Product product); 
}
