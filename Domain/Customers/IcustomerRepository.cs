
namespace Domain.Customers;
public interface IcustomerRepository
{
    Task<Customer?> GetByIdAsync(CustomerId id);
    Task Add(Customer customer); 
}
