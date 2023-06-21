using Domain.Customers;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Order order)
        {
            _context.Add(order);
        }

        public async Task<Order?> GetByIdWithLineItemAsync(OrderId id, LineItemId lineItemId)
        {
            return await _context.Orders.Include(o=> o.LineItems.Where(li=> li.Id == lineItemId))
                        .SingleOrDefaultAsync(o=> o.Id == id);
        }

        public bool HasOneLineItem(Order order)
        {
            return _context.LineItems.Count(li => li.OrderId == order.Id) == 1;
        }
    }
}
