using Domain.Customers;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public Task<Order?> GetByIdWithLineItemAsync(OrderId id, LineItemId lineItemId)
        {
            throw new NotImplementedException();
        }

        public bool HasOneLineItem(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
