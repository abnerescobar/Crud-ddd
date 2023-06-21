using Microsoft.EntityFrameworkCore;
using Domain.Customers;
using Domain.Products;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; set; }
    DbSet<Product> Products { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
